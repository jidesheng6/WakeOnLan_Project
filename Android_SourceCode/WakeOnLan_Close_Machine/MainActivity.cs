using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using WakeMain;

namespace WakeOnLan_Close_Machine
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Toast.MakeText(this, "注意：本工具只能在局域网中使用，Mac地址请从电脑工具中获取，关机操作，如果此局域网中有点电脑运行了服务也会被关闭，将来考虑出2.0版本。", ToastLength.Long).Show();
            EditText Mac_Address_Text = FindViewById<EditText>(Resource.Id.Mac_AddressText);
            Button OpenButton = FindViewById<Button>(Resource.Id.OpenButton);
            Button CloseButton = FindViewById<Button>(Resource.Id.CloseButton);
            OpenButton.Click += (sender, e) =>
             {
                 if (Mac_Address_Text.Text!="")
                 {
                     MainCode.WakeMachine(Mac_Address_Text.Text.Trim());
                 }
                 else
                 {
                     Toast.MakeText(this, "傻逼吧你，差点退出了，多少沾丶脑瘫", ToastLength.Long).Show();
                 }
                 


             };
            CloseButton.Click += (sender, e) =>
              {
                 MainCode.CloseMachines();
              };
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}