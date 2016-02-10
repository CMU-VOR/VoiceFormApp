####Sphinx Installation Manual

=========================================================

#####Prerequisites

* Windows 10 Education [<https://www.cmu.edu/computing/software/all/dreamspark/>]
* Visual Studio Premium 2012 [<https://www.cmu.edu/computing/software/all/dreamspark/>]
* CMU Sphinx [<http://cmusphinx.sourceforge.net/wiki/download>]
* Create a new folder with the name **\sphinx**

##### Sphinx Toolkit

* PocketSphinx — recognizer library written in C.
* SphinxTrain — acoustic model training tools
* SphinxBase — support library required by PocketSphinx and SphinxTrain

##### Installing SphinxBase

* Download the package and unzip it.
* Enter the unzipped folder and get the **\sphinxbase** folder.
* Move the **\sphinxbase** folder into the **\sphinx** folder.
* Load the **sphinxbase.sln** project with Visual Studio 2012.
* Change the Local Windows Debugger to **Release**.
* Select **Build** and then choose **Rebuild Solution**.
* Wait until successful.


##### Installing PocketSphinx

* Download the package and unzip it.
* Enter the unzipped folder and get the **\pocketsphinx** folder.
* Move the **\pocketsphinx** folder into the **\sphinx** folder, make sure it has the same parent directory with the **\sphinxbase** folder.
* Load the **pocketsphinx.sln** project with Visual Studio 2012.
* Change the Local Windows Debugger to **Release**.
* Select **Build** and then choose **Rebuild Solution**.
* Wait until successful.


#####Installing SphinxTrain

* Download the package and unzip it.
* Enter the unzipped folder and get the **\sphinxtrain** folder.
* Move the **\sphinxtrain** folder into the **\sphinx** folder, make sure it has the same parent directory with the **\sphinxbase** folder and the **\pocketsphinx** folder.
* Load the **SphinxTrain.sln** project with Visual Studio 2012.
* Change the Local Windows Debugger to **Release**.
* Select **Build** and then choose **Rebuild Solution**.
* Wait until successful.

