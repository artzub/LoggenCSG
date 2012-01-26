using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.EntityClient;
using System.Data.SQLite;

namespace Logger {
	public class GephiAppender : SQLiteAppender {
		private gephiEntities gephi;

		private gephiEntities Gephi {
			get {
				if (gephi == null) {

					if (System.IO.File.Exists(connectionString)) {
						System.IO.File.Delete(connectionString);
					}

					var con = new EntityConnectionStringBuilder();
					con.Metadata = @"res://*/GephiModel.csdl|res://*/GephiModel.ssdl|res://*/GephiModel.msl";
					con.Provider = "System.Data.SQLite";
					con.ProviderConnectionString = 
						new SQLiteConnectionStringBuilder() {
							DataSource = connectionString
						}.ToString();
					gephi = new gephiEntities(con.ConnectionString);

					gephi.ExecuteStoreCommand("CREATE TABLE [Nodes] (" +
						"[Id] INTEGER NOT NULL ON CONFLICT ABORT PRIMARY KEY ON CONFLICT ABORT AUTOINCREMENT, " +
						"[Label] VARCHAR2 NOT NULL ON CONFLICT ABORT, " +
						"[Size] INTEGER DEFAULT (1), " +
						"[Start] DATETIME, " +
						"[End] DATETIME, " +
						"[X] INTEGER, " +
						"[Y] INTEGER)");

					gephi.ExecuteStoreCommand("CREATE UNIQUE INDEX [uknode] ON [Nodes] ([Label] COLLATE RTRIM ASC)");

					gephi.ExecuteStoreCommand("CREATE TABLE [Edges] (" +
						"[Id] INTEGER NOT NULL ON CONFLICT ABORT PRIMARY KEY ON CONFLICT ABORT AUTOINCREMENT, " + 
						"[Source] INTEGER NOT NULL ON CONFLICT ABORT CONSTRAINT [fksource] REFERENCES [Nodes]([Id]) ON DELETE CASCADE, " +
						"[Target] INTEGER NOT NULL ON CONFLICT ABORT CONSTRAINT [fktarget] REFERENCES [Nodes]([Id]) ON DELETE CASCADE, " +
						"[Size] INTEGER DEFAULT (1), " +
						"[Start] DATETIME, " +
						"[End] DATETIME)");

					gephi.ExecuteStoreCommand("CREATE UNIQUE INDEX [ukedge] ON [Edges] ([Source] ASC, [Target] ASC)");
				}
				return gephi;
			}
		}

		public GephiAppender(string dbfilepath) : 
			base(dbfilepath) {
		}

		private Int64 GetTime(DateTime date) {
			Int64 retval = 0;
			TimeSpan t = date - DateTime.Parse("1970/1/1");
			retval = Convert.ToInt64(t.TotalSeconds);
			//(Int64)(t.TotalMilliseconds + 0.5);
			return retval;
		}

		private string connectionString;

		protected override void AddData(LogEvent logEvent) {

			var source = Gephi.Nodes.Where(
				x => logEvent.User.Equals(x.Label)).FirstOrDefault();

			if (logEvent.Date.Ticks == 0)
				logEvent.Date = DateTime.Now;

			if (source == null) {
				source = new Node() {
					Label = logEvent.User,
					Start = logEvent.Date,
					End = DateTime.Now,
					Size = 1
				};
				Gephi.AddToNodes(source);
			}
			else {
				source.Size++;
				if (source.Start > logEvent.Date)
					source.Start = logEvent.Date;
			}
			Gephi.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave | System.Data.Objects.SaveOptions.DetectChangesBeforeSave);

			var from = logEvent.FileName;

			var target = Gephi.Nodes.Where(
				x => from.Equals(x.Label)).FirstOrDefault();

			if (target == null) {
				target = new Node() {
					Label = from,
					Start = logEvent.Date,
					End = DateTime.Now,
					Size = 1
				};
				Gephi.AddToNodes(target);
			}
			else {
				if (target.Start > logEvent.Date)
					target.Start = logEvent.Date;
				target.Size++;
			}
			Gephi.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave | System.Data.Objects.SaveOptions.DetectChangesBeforeSave);

			var edge = Gephi.Edges.Where(
				x => x.Source == source.Id && x.Target == target.Id).FirstOrDefault();

			if (edge == null) {
				edge = new Edge() {
					Source = source.Id,
					Target = target.Id,
					Start = logEvent.Date,
					End = DateTime.Now,
					Size = 1
				};
				Gephi.AddToEdges(edge);
			}
			else {
				edge.Size++;
				if (edge.Start > logEvent.Date)
					edge.Start = logEvent.Date;
			}
			Gephi.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave | System.Data.Objects.SaveOptions.DetectChangesBeforeSave);

			from = logEvent is GephiLogEvent && 
				!string.IsNullOrWhiteSpace((logEvent as GephiLogEvent).From) ? 
				(logEvent as GephiLogEvent).From : string.Empty;

			if (!string.IsNullOrWhiteSpace(from)) {
				source = Gephi.Nodes.Where(
					x => from.Equals(x.Label)).FirstOrDefault();

				if (source == null) {
					source = new Node() {
						Label = from,
						Start = logEvent.Date,
						End = DateTime.Now,
						Size = 1
					};
					Gephi.AddToNodes(source);
				}
				else {
					if (source.Start > logEvent.Date)
						source.Start = logEvent.Date;
					source.Size++;
				}
				Gephi.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave | System.Data.Objects.SaveOptions.DetectChangesBeforeSave);

				edge = Gephi.Edges.Where(
					x => x.Source == target.Id && x.Target == source.Id).FirstOrDefault();

				if (edge == null) {
					edge = new Edge() {
						Source = target.Id,
						Target = source.Id,
						Start = logEvent.Date,
						End = DateTime.Now,
						Size = 1
						/*logEvent is LogstalgiaEvent ? Convert.ToInt64((logEvent as LogstalgiaEvent).Size) : 1*/
					};
					Gephi.AddToEdges(edge);
				}
				else {
					if (edge.Start > logEvent.Date)
						edge.Start = logEvent.Date;
					edge.Size++;
				}
				Gephi.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave | System.Data.Objects.SaveOptions.DetectChangesBeforeSave);
			}
		}

		protected override void InitContext(string dbfilepath) {
			connectionString = dbfilepath;
		}

		public override void Dispose() {
			if (gephi != null)
				gephi.Dispose();
		}
	}
}
