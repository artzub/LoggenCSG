using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Samples.Helper;
using Google.Apis.Util;

namespace LoggenCSG {
	static class Program {
		public static void ShowError(this Exception ex, IWin32Window owner = null) {
			MessageBox.Show(
				owner,
				ex.Message + (
					ex.InnerException != null ?
						"\n" + ex.InnerException.Message :
						""
				),
				"Error",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
			);
		}

		public static bool IsEmpty(this string str) {
			return string.IsNullOrWhiteSpace(str);
		}

		public static bool IsNotEmpty(this string str) {
			return !str.IsEmpty();
		}

		#region by Google

		/*
		Copyright 2011 Google Inc

		Licensed under the Apache License, Version 2.0(the "License");
		you may not use this file except in compliance with the License.
		You may obtain a copy of the License at

			http://www.apache.org/licenses/LICENSE-2.0

		Unless required by applicable law or agreed to in writing, software
		distributed under the License is distributed on an "AS IS" BASIS,
		WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
		See the License for the specific language governing permissions and
		limitations under the License.
		*/


		private static IAuthenticator CreateAuthenticator() {
			var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description);
			provider.ClientIdentifier = ClientCredentials.ClientID;
			provider.ClientSecret = ClientCredentials.ClientSecret;
			return new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthentication);
		}

		private static IAuthorizationState GetAuthentication(NativeApplicationClient client) {
			// You should use a more secure way of storing the key here as
			// .NET applications can be disassembled using a reflection tool.
			const string STORAGE = "google.samples.dotnet.plus";
			const string KEY = "y},drdzf11x9;87";
			string scope = Google.Apis.Plus.v1.PlusService.Scopes.PlusMe.GetStringValue();

			// Check if there is a cached refresh token available.
			IAuthorizationState state = AuthorizationMgr.GetCachedRefreshToken(STORAGE, KEY);
			if (state != null) {
				try {
					client.RefreshToken(state);
					return state; // Yes - we are done.
				}
				catch (DotNetOpenAuth.Messaging.ProtocolException ex) {
					ex.ShowError();
				}
			}

			// Retrieve the authorization from the user.
			state = AuthorizationMgr.RequestNativeAuthorization(client, scope);
			AuthorizationMgr.SetCachedRefreshToken(STORAGE, KEY, state);
			return state;
		}

		public static IAuthenticator OAuth2 {
			get;
			private set;
		}

		#endregion
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			try {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				OAuth2 = CreateAuthenticator();

				Application.Run(new mainForm());
			}
			catch (Exception ex) {
				ex.ShowError();
			}
		}
	}
}
