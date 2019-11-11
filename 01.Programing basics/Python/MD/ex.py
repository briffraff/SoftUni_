from PythonQt import QtCore, QtGui, MarvelousDesignerAPI
from PythonQt.MarvelousDesignerAPI import *
import MarvelousDesigner
from MarvelousDesigner import *

class mdTestClass():
    mdsa = None
    avatar_listWidget = None
    garment_listWidget = None
    animation_listWidget = None
    save_listWidget = None
    avatar_ext_comboBox = None
    garment_ext_comboBox = None
    animation_ext_comboBox = None
    save_ext_comboBox = None
    widget = None
    save_folder_path = ""

    def loadAvatarAndSaveProject(self, object):
        # clear console window
        #object.clear_console()

        #initialize mdsa module
        object.initialize()

        #set exporting option
        object.set_open_option("cm", 30)
        object.export_unified_map = True
        object.export_thin = True
        object.export_weld = False

        #set importing option
        object.set_save_option("cm", 30, False)

        #Set the path of an Avatar file you want to load.
        object.set_avatar_file_path(r"M:\MD_N\Avatars\Mannequins Morphable\Mens\MA-2.OBJ")

        object.set_garment_file_path(r"M:\MD_N\Garments\06 LS\N06M004_Pro\Garment\N06M004_MA-2.zpac")
        object.sync_file_lists("garment")
        object.set_garment_file_path(r"M:\MD_N\Garments\01 Pants\N01M002_Cuffed\Garments\N01M002_MA-2_0.zpac")
        object.sync_file_lists("garment")

        fileName = object.get_file_name(r"M:\MD_N\Garments\06 LS\N06M004_Pro\Garment\N06M004_MA-2.zpac")
        split = fileName.split("_")
        a = split[0]
        b = split[1].split(".")[0]
        garmentCode = a + "_" + b

        object.set_simulation_quality(1)
        object.set_simulation_number_of_cpu_in_use(10)
        object.set_simulation_ground_collision(True)

        #Set simulation option.
        object.set_simulation_options(0, 0, 15000)

        #Set the saving file path.
        object.set_save_file_path(r"C:\Users\BorisoB\Desktop\marvelous test\scriptTest\test_project2.zprj")

        object.on_export_garment_only()

        object.set_save_file_path(r"C:\Users\BorisoB\Desktop\marvelous test\Obj" + "\\" + "SM_" + garmentCode + "_0.obj")

        #set auto save option. True is save with Zprj File and Image File.
        object.set_auto_save(True)

        #If you finish setting file paths and options. You must call process function.
        object.process()




