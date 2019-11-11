from PythonQt import QtCore, QtGui, MarvelousDesignerAPI
from PythonQt.MarvelousDesignerAPI import *
import MarvelousDesignerAPI
from MarvelousDesignerAPI import *

#concat the paths and names
thePath = r"M:\MD_N\Garments YA\09 Jackets\N09B012_AcademyI96\Garments"
theObject = "N09B012_YAB-1_0"
fullPathToObject = (thePath + "\\" + theObject)
splitted = fullPathToObject.split("\\")

avatarPath = r"M:\MD_N\Avatars\Mannequins Morphable\Young Athletes"
avatarName = "YAB-1"

pathToSaveObj = r"M:\MD_N\Garments YA\09 Jackets\N09B012_AcademyI96\Obj"

#get the garment name
nameOfObject = splitted[4] #N09B012_AcademyI96

#split the garment name
codeAndName = nameOfObject.split("_")
garmentCode = codeAndName[0]
garmentName = codeAndName[1]

class garmentche():

    def yaGarmentFunction(self, object):

        object.clear_console()

        object.initialize()

        object.set_open_option("mm", 30)

        object.set_save_option("cm", 30, True)
        object.export_unified_map = True
        object.export_thin = True
        object.export_weld = False

        object.set_avatar_file_path(avatarPath + "\\" + avatarName + ".obj")

        object.set_garment_file_path(thePath + "\\" + theObject + ".zpac")

        object.set_simulation_options(0, 0, 5000, True)

        object.set_save_file_path(pathToSaveObj + "\\" + "SM_" + garmentCode + "_" + avatarName + "_0_ExpoTest.obj")

        object.process()


