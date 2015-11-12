# PushApp
PUSHAPP

PushApp is a workflow automation application.  Simply put, it copies files from one folder to another.  The intent is:

1.	Reduce the number of steps required to copy data.
2.	Eliminate errors when copying data manually.

EPIC
The user wants to copy image files generated by a scanning workstation to an image editing workstation.  The user wants to simplify that copy process.  The user doesn't��t want to have to use Windows Explorer to manually Copy/Move files.  The user does not use the scanning workstation frequently so they may be prone to making mistakes.  The file management features in the scanning application are clumsy and have limited capability.

SCANNING WORK STATION
A legacy film scanning application (2005) creates files in a specific location on the file system. The application is not compatible with current Windows 7/10.  The application must run on Win XP.  The user has purchased a Laptop PC and installed XP to support the application. The source code for the legacy application is not available. 

The laptop must not be updated with new drivers.  Changes will cause the legacy application to fail.  The legacy application will function with .NET 4.0 installed.

This laptop must not be connected to the Internet directly but must be able to connect to the edit workstation.  

EDIT WORKSTATION
The edit workstation is a Win 7/10 PC.  A second Ethernet card provides a link to the scanning workstation.  This P2P network is in a different domain so the scanning workstation is protected.

Comments:  This is un-factored code.  There are many duplicate blocks of code that will be refactored before release.  There are many constant values related to configuration that will be removed.  This code has not been heavy tested but does work properly in XP.  This code is available to review and comment.  This code is not ready for release.

-------------------------------------------------------------------------------

##FEATURE BRANCH - Sub folder feature

Data files and application files are typically stored in sub folders. Push should be able to find, copy/move, and delete these files and sub folders when appropriate. Not all sub folders and files should be processed. Push should be able to exclude certain files and sub folders when processing.  

-------------------------------------------------------------------------------

###USER STORY - Find all sub folders and files in sub folder.

As a user, I should be able to see any sub folders in the default source and target folders.

The current code base doesn't recognize or scan sub folders when they are in the source or target folder.
The application should be able to scan all sub folders underneath the configured source and target folders.
Only the top level folders will be visible in the UI, but all sub folder levels will be scanned.

-------------------------------------------------------------------------------

###USER STORY - Copy/Move sub folders and data from target to source folder.

As a user, I want to be able to copy/move all sub folders and data from the source to the target folder.

New sub folders will be created.
Existing sub folders will be updated.  They will NOT be renamed like files.

-------------------------------------------------------------------------------

###USER STORY - Delete sub folders and files from source folder.

As a user, I want to be able to delete all sub folders and data in the source folder after a Copy action has completed.

If a child sub folder or file is excluded, the parent sub folder will not be deleted.

-------------------------------------------------------------------------------

###USER STORY - Exclude List

As a user, I want to prevent certain files and folders from being copied.

A new filter will be added for exclusions.
Any excluded folder will automatically exclude any child.
The exclusion list will be a simple text file with paragraph/line-feed delimited entries.

-------------------------------------------------------------------------------
