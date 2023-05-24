using Firebase.Database;
using Firebase.Storage;
namespace Mobile_App_Enriquez;

public partial class App : Application
{
	public static FirebaseClient client = new("https://employeeinfodb-default-rtdb.asia-southeast1.firebasedatabase.app/");
	public static FirebaseStorage firebaseStorage = new("employeeinfodb.appspot.com");
	public static FileResult _mainimgResult, _img1Result, _img2Result, _img3Result,
            _img4Result, _img5Result, _img6Result;

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
