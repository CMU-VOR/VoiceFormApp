#Olympus Installation Manual 
=========
#####Prerequisites and Reference Links

* Windows 10 Education [<https://www.cmu.edu/computing/software/all/dreamspark/>]
* Visual Studio 2012 [<https://www.microsoft.com/en-us/download/details.aspx?id=34673>]
* TortoiseSVN [<http://tortoisesvn.tigris.org/>]
* Kitware's CMake 2.8.3 [<http://pkgs.fedoraproject.org/repo/pkgs/cmake/>]
* AvtiveState Perl [<http://www.activestate.com/activeperl>]
* Python2.7 [<https://www.python.org/download/releases/2.7/>]
* NetBeans with JDK 8 [<http://www.oracle.com/technetwork/java/javase/downloads/index.html>]


#####Installing Process

1. Environment Variables
	
	Set up the **JAVA_HOME** to let the system know the location of **JDK**.

2. Download Olympus

	In order to download the Olympus package, you need to use the **TortoiseSVN** that has just been installed. Go to the folder that you want the Olympus package to be located, for example the /Documents folder, right click at any blank place and select **SVN Checkout**, the GUI of TortoiseSVN will appear. Type in the following link, then the Olympus package will be downloaded to the current directory.

	```
	svn co http://trac.speech.cs.cmu.edu/svn/olympus/tags/2.6.1
	```

3. Install the **Win32::RunAsAdmin** and **Win32::Env** module with the following command line.
	
	```
	ppm install Win32::RunAsAdmin
	ppm install Win32::Env
	```
	
4. Open the command line tool **Developer Command Prompt for VS2012** (Developer Command Prompt for VS2015 is not acceptable) and select **Run As Administrator**, then navigate into the Olympus folder. Use the following command to install the Olympus package.

	```
	OlympusRebuild.bat	
	```
	
	System will automatically compile and install the Olympus package and related modules.
	The command line would give feedback on installing process, which would also be saved to **build.log**.
	
	If there is error with **CMake**, use **CMake 2.8.10** instead of the newest released version 
	

#####Test and Sample Code

Download the example project at <http://trac.speech.cs.cmu.edu/svn/olympus/example-systems> and run **SystemBuild.pl** to test the installation of the package.


#####Resources
1.  http://wiki.speech.cs.cmu.edu/olympus/index.php/Download
