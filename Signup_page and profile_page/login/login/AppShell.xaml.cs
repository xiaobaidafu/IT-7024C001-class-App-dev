namespace login
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //nameof  and typeof 
            //like a house and and give the direction to the house 
            //just like a webside
            //when button chicked we use shell.current.gotoasync to the page
            Routing.RegisterRoute(nameof(ProfilePage),typeof(ProfilePage)); 

            Routing.RegisterRoute(nameof(SignupPage), typeof(SignupPage));
        }
    }
}
