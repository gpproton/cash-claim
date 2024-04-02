﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace CashClaim.Mobile;

[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
[IntentFilter(new[] { Android.Content.Intent.ActionView },
 Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
 DataScheme = CALLBACK_SCHEME)]
public class WebAuthenticationCallbackActivity : WebAuthenticatorCallbackActivity {

    const string CALLBACK_SCHEME = "xclaim";

    protected override void OnCreate(Bundle savedInstanceState) {
        base.OnCreate(savedInstanceState);
    }
}