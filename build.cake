// Define the required parameters
var DefaultSolutionName = "Orc.Prism";
var DefaultCompany = "WildGums";
var DefaultRepositoryUrl = string.Format("https://github.com/{0}/{1}", DefaultCompany, DefaultSolutionName);
var StartYear = 2014;

// Note: if assembly name equals project name, this can be string.Empty;
var DefaultCodeSignWildCard = "Orc.Prism";

// Note: the rest of the variables should be coming from the build server,
// see `/deployment/cake/*-variables.cake` for customization options

//=======================================================

// Components

var ComponentsToBuild = new string[]
{
    "Orc.Prism5", 
    "Orc.Prism6"
};

//=======================================================

// WPF apps

var WpfAppsToBuild = new string[]
{

};

//=======================================================

// UWP apps

var UwpAppsToBuild = new string[]
{

};

//=======================================================

// Test projects

var TestProjectsToBuild = new string[]
{
    "Orc.Prism5.Tests",
    "Orc.Prism6.Tests"
};

//=======================================================

// Now all variables are defined, include the tasks, that
// script will take care of the rest of the magic

#l "./deployment/cake/tasks.cake"