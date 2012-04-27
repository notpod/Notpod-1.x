# Installer script for Notpod
!define PRODUCT_NAME "Notpod"
!define PRODUCT_VERSION "1.5 BETA"
!define MUI_ABORTWARNING
!define MUI_ICON ".\Resources\ita-new.ico"
!define MUI_UNICON ".\Resources\ita-new.ico"

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "notpod-${PRODUCT_VERSION}-installer.exe"

InstallDir "$PROGRAMFILES\${PRODUCT_NAME}"
BrandingText "${PRODUCT_NAME}"
	
!include "MUI2.nsh"

!define MUI_WELCOMEPAGE_TITLE_3LINES
!define MUI_WELCOMEPAGE_TITLE "${PRODUCT_NAME} ${PRODUCT_VERSION}"
!define MUI_WELCOMEPAGE_TEXT "Welcome to the installation program for ${PRODUCT_NAME} ${PRODUCT_VERSION}.$\r$\n$\r$\nThis program will install ${PRODUCT_NAME} ${PRODUCT_VERSION} onto your computer. Please make sure you save any open files before you continue. Please read the instructions and information carefully throughout this installation.$\r$\n$\r$\nThanks for choosing ${PRODUCT_NAME}! We hope you will enjoy the application."
!define MUI_WELCOMEFINISHPAGE_BITMAP "Resources\installer-welcome-img.bmp"
!insertmacro MUI_PAGE_WELCOME

!define MUI_PAGE_HEADER_TEXT "${PRODUCT_NAME} ${PRODUCT_VERSION} License"
!define MUI_PAGE_HEADER_SUBTEXT "Please read and accept the application license."
!insertmacro MUI_PAGE_LICENSE "LICENSE.TXT"

!define MUI_PAGE_HEADER_TEXT "${PRODUCT_NAME} ${PRODUCT_VERSION} installation information"
!define MUI_PAGE_HEADER_SUBTEXT "Make sure you read this carefully before continuing."
!insertmacro MUI_PAGE_LICENSE "Docs\INSTALL NOTES BETA.TXT"

!define MUI_PAGE_HEADER_TEXT "Installation location"
!define MUI_PAGE_HEADER_SUBTEXT "Where do you want ${PRODUCT_NAME} installed?"
!insertmacro MUI_PAGE_DIRECTORY


!define MUI_TEXT_INSTALLING_TITLE "Now installing ${PRODUCT_NAME} ${PRODUCT_VERSION}..."
!insertmacro MUI_PAGE_INSTFILES

!insertmacro MUI_LANGUAGE "English"
 
 Section "${PRODUCT_NAME}" SecMain


        SetOutPath "$INSTDIR"
        File "bin\Release\Notpod.exe"
        File "bin\Release\log4net.dll"
        File "bin\Release\Interop.iTunesLib.dll"
        File "LICENSE.TXT"
        SetOutPath "$INSTDIR\Resources"
		File "bin\Release\Resources\logging.xml"
		File "bin\Release\Resources\syncpatterns.xml"
		
		createShortCut "$SMPROGRAMS\${PRODUCT_NAME}\${PRODUCT_NAME}.lnk" "$INSTDIR\${PRODUCT_NAME}.exe"
        createShortCut "$SMPROGRAMS\${PRODUCT_NAME}\Uninstall.lnk" "$INSTDIR\uninstaller.exe"
        
        # define uninstaller name
        writeUninstaller $INSTDIR\uninstaller.exe

 SectionEnd
 
 Section "Uninstall"

    # Always delete uninstaller first
    delete $INSTDIR\uninstaller.exe

    # now delete installed file
    delete $INSTDIR\Notpod.exe
    delete $INSTDIR\log4net.dll
    delete $INSTDIR\Resources\logging.xml
	delete $INSTDIR\Resources\syncpatterns.xml
    delete $INSTDIR\LICENSE.txt
	delete $INSTDIR\notpod.log
	delete $INSTDIR\Interop.iTunesLib.dll
	delete $INSTDIR

 SectionEnd
