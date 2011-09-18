# Installer script for Notpod
!define PRODUCT_NAME "Notpod"
!define PRODUCT_VERSION "1.4"
!define MUI_ABORTWARNING
!define MUI_ICON ".\Resources\ita-new.ico"
!define MUI_UNICON ".\Resources\ita-new.ico"
!define MUI_WELCOMEPAGE_TITLE_3LINES "Line 1$\r$\n$Line2$\r$\n$Line3"
!define MUI_WELCOMEPAGE_TITLE "${PRODUCT_NAME} ${PRODUCT_VERSION}"
!define MUI_WELCOMEPAGE_TEXT "Welcome to the installation program for ${PRODUCT_NAME} ${PRODUCT_VERSION}.$\r$\n$\r$\nThis program will install ${PRODUCT_NAME} ${PRODUCT_VERSION} onto your computer. Please make sure you save any open files before you continue. Please read the instructions and information carefully throughout this installation.$\r$\n$\r$\nThanks for choosing ${PRODUCT_NAME}! We hope you will enjoy the application."
!define MUI_PAGE_HEADER_TEXT "${PRODUCT_NAME} ${PRODUCT_VERSION}"
!define MUI_WELCOMEFINISHPAGE_BITMAP ".\Resources\installer-welcome-img.bmp"
!define MUI_TEXT_LICENSE_TITLE "Please read and accept the license to continue."

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "notpod-${PRODUCT_VERSION}-installer.exe"

InstallDir "$PROGRAMFILES\${PRODUCT_NAME}"
BrandingText "${PRODUCT_NAME}"
	
!include "MUI2.nsh"

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "LICENSE.TXT"
!insertmacro MUI_PAGE_LICENSE "Docs\INSTALL NOTES.TXT"
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

 
 Section "${PRODUCT_NAME}" SecMain


        SetOutPath "$INSTDIR"
        File "bin\Release\Notpod.exe"
        File "bin\Release\log4net.dll"
        File "bin\Release\logging.xml"
        File "bin\Release\Interop.iTunesLib.dll"
        File "LICENSE.TXT"
        createShortCut "$SMPROGRAMS\Notpod.lnk" "$INSTDIR\Notpod.exe"
        
        # define uninstaller name
        writeUninstaller $INSTDIR\uninstaller.exe

 SectionEnd
 
 Section "Uninstall"

    # Always delete uninstaller first
    delete $INSTDIR\uninstaller.exe

    # now delete installed file
    delete $INSTDIR\Notpod.exe
    delete $INSTDIR\log4net.dll
    delete $INSTDIR\logging.xml
    delete $INSTDIR\Interop.iTunesLib.dll

 sectionEnd