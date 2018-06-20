# GETrueConnectInterface
This is UI tool for GE's true connect console application.
GE trueconnect github can be found here: https://github.com/GeneralElectric/TrueConnect-Link

This tool provides UI for 4 core features in Trueconnectlink
1. Test
2. Single File Upload
3. Onetime file upload
4. Auto File upload

User will need:
- GE Trueconnect credentials
- Visual studio to compile the code

To use tool as is you do not need any programming skills.

Steps:
1. Download the source code and read README and LICENSE file.
2. Make sure that you have visual studio installed on your machine, and open the project (.sln) file.
3. Navigate to \TrueConnectInterface\Settings.cs (VS: Settings.cs>View code)
4. Navigate to line 13
5. Modify line 13-21 and put in all the values provided by GE.
6. Navigate to TrueConnectInterface\Properties\AssemblyInfo.cs (VS: Properties\AssemblyInfo.cs)
7. Navigate to line 8
8. Modify line 8-15 (Refer License agreement)
9. Save all changes and Build/Compile the code, obtain the EXE file from bin folder and use application as standalone executable.

Important!
If there is update from GE on their console application make sure that exe is included in resource folder as "TrueConnectLink.exe"
