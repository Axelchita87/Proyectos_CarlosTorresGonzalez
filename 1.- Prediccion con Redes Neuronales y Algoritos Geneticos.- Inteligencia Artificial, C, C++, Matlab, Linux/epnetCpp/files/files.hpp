/*!
 *  files.hpp
 *  File operations
 *
 * Created: 	May 8th 2011
 * Modified:
 * Auhtor: 	Carlos Torres and Victor Landassuri
 * 
 */

#ifndef FILES_HPP
#define FILES_HPP




bool FileExists(string strFilename) {
	/*!
	 * Function to determinate if a file or directory exist
	 */
  struct stat stFileInfo;
  bool blnReturn;
  int intStat;

  // Attempt to get the file attributes
  intStat = stat(strFilename.c_str(),&stFileInfo);
  if(intStat == 0) {
    // We were able to get the file attributes, so the file obviously exists.
    blnReturn = true;
  } else {
    // We were not able to get the file attributes.
    // This may mean that we don't have permission to access the folder which contains this file. If you
    // need to do that level of checking, lookup the return values of stat which will give you
    // more details on why stat failed.
    blnReturn = false;
  }

  return(blnReturn);
}


int countFiles(string dir){
	/*!
	 * Function to count the files in a directory
	 * I have not check if it takes directories as files
	 */

	// uses #include <dirent.h>, these two lines
	DIR * dirp;
	struct dirent * entry;
	int files = 0;

	dirp = opendir(dir.c_str()); 							// There should be error handling after this, however before I checked for it
	while ((entry = readdir(dirp)) != NULL) {
		if (entry->d_type == DT_REG) { 				// If the entry is a regular file
			files++;
		}
	}
	closedir(dirp);

	return (files);

}




static void load_FixedInputs_and_Delay(int *Inputs, int *Delays)
{
	/*! initialize the Inputs and delays of the network, if they are fixed, from VRA
     *  The format of the file to read is: maxInputs noInputsDelay
     */

   FILE *ff;

    //open file//
   if((ff = fopen(VRAvals.c_str(),"r")) == NULL){
        printf("Error cannot open 'FixedInputsVals' for reading...:( \n");
        exit(0);
    }
    //copy values in global variables
    if(fscanf(ff,"%d %d",&Inputs[0], &Delays[0])!= EOF)
    {
    	cout << "VRA values loaded" << endl;
    }

    fclose(ff);
}//////////////////////////////////////////////////////////////////////////





static void load_inputs_and_classes(int *Inp, int *Cla)
{
	/*! initialize the Inputs and classes, if they are fixed or fixed and evolved
     * The format of the file to read is: inputs classes
     */

   FILE *ff;

    //open file//
   if((ff = fopen(inpClass.c_str(),"r")) == NULL){
        printf("Error cannot open 'txtFiles/numberInputsANDClasses.txt' for reading...:( \n");
        exit(0);
    }
    //copy values in global variables
    if(fscanf(ff,"%d %d",&Inp[0], &Cla[0])!= EOF)
    {
    	cout << "inputs and classes values loaded" << endl;
    }

    fclose(ff);
}//////////////////////////////////////////////////////////////////////////






static void SetSizeDatainput(void){
	/*!
	 * Function to count the lines and columns of the file
	 * code in C++
	 */

	int lines = 0, cols = 0, cont = 0;
	string line;

	ifstream myfile ( INPUTF.c_str() );
	if (myfile.is_open())
	{
		while (! myfile.eof() )
		{
			getline (myfile,line);
			if (cont == 0){
				stringstream is(line);
				float n;
				while (is >> n){
					//cout << n << endl;
					cols++;					//Count the Cols
				}
				cont++;
			}
			if (line.empty()){
				//cout << "Reading file: Empty line at position: " << lines+1  << endl;
				break;
			}
			//cout << line << endl;
			lines++;						//Count the Lines
		}
		myfile.close();
	}
	else{
		cout << "Unable to open file " << INPUTF.c_str() << endl;
		exit(1);
	}

	// Check which value is going to be used
	if (maxdata <= lines)
		fileline = maxdata;

	if (lines < maxdata)
		fileline = lines;
	//else{
	//	cout << "You ask for more information (lines in file) that the actual, Exit code 0..., check your file and conf.hpp..." << endl;
	//	cout << " Lines in file: " << lines << ", Lines request: " << maxdata << endl;
	//}

	filecol = cols;
	//cout << "Lines = " << fileline <<  ", Columns = " << filecol << endl;

}






void checkDir(void){
	/*!
	 * checkDir
	 * Function to check if the requirted directories exist in the main directory of the experiment
	 * If they do not exit, create them
	 * If they cannot be created, then the program exists, before run anything
	 */


	// Fisrt check if the res directory is present, this is normaly tested in the script to run all runs, but here is tested just in case
	if (FileExists("res") == false ){ 					// if does not exist
		if (system("mkdir res") == -1){ 				// create it
			cout << "There has been an error creating the directory 'res', exit ..." << endl;
			exit(0);
		}
	}

	// Now check for the directory where each ANN from the popoulation is saved
	if (saveNets2beReloaded == ON){
		if (FileExists("resPop") == false ){
			if ( system("mkdir resPop") == -1 ){
				cout << "There has been an error creating the directory 'resPop', exit ..." << endl;
				exit(0);
			}
		}
	}

	// Check the pool of modules
	if (saveModulesINpool == ON){
		if (FileExists("../pool") == false ){
			if ( system("mkdir ../pool") == -1 ){
				cout << "There has been an error creating the directory '../pool', exit ..." << endl;
				exit(0);
			}
		}
	}


} // END checkDir function


string loadNameTS(void){
	/*!
	 * Load the name of the TS
	 * Note that the file must have just one line containing the name, if more than one line it has, I have not check waht happend
	 *
	 * It is load waht type of data set it is, A, B, C, ..., Those values are used to determinate if it is used the winner takes all, and the other methods
	 *
	 * Created: 	between 2008-2010
	 * Modified: 26 Apr 2011
	 * Author: 	Carlos Torres and Victor Landassuri
	 */

	string name = "";

	// check if file exist
	if ( FileExists( TSName.c_str() ) == true ){
		// read contents of file "TSname" into buf, discarding newlines

		string line;
		ifstream in( TSName.c_str() );
		while(getline(in,line))
			name += line;
		//cout << "read: " << nameTS << "\n";
		in.close(); // close the file
	}

	// load type of data set only for calssification tasks for the moment
	if (task2solve == CLASSIFY){
		// check if file exist
		if ( FileExists( TYPEDS.c_str() ) == true ){
			// read contents of file "TSname" into buf, discarding newlines

			string line2;
			ifstream in( TYPEDS.c_str() );
			while(getline(in,line2))
				typeDS += line2;													// global variable, mainepnet.hpp file
			cout << "read: " << typeDS << "\n";
			in.close(); // close the file
		}
		else{
			cout << "The file txtFiles/typeDS.txt does not exist..... exit.... function:  loadNameTS" << endl;
			exit (0);
		}
	}

	return (name);

} // End Load name of the TS



void setPathDirectories(void){ // FOR THE MOMENT IS NOT UED
	/*!
	 * #Set the path of the directories
	 * Note that before all files where on txtFiles
	 * Now they are some leves up from the directory of the xperiment to not have many repetition of the same
	 * files
	 *
	 * This file override the file filePath.hpp
	 * If you do nnot call this functino from the main, you can still using the file to load the data set from the normal directory
	 *
	 * IMPORTNAT
	 *  The conf.hpp file when added into the mainepnet.hpp is set at hand CAREFUL remain in txtFiles/  as it was difficultt to move it, the resat remain in the main directory of data sets
	 *
	 * Created: 	7 Aug
	 * Modified:
	 * Author: 	Carlos Torres and Victor Landassuri
	 *
	 */
	int i = 0;//, sysTMP = 0;

	string pathTmp= "";
	string upDir = "../";
	string dirDataSets = "dataSetsPhD";
	string finalPath = dirDataSets;  		// contain the path where the data base is at first stage
	string stringLS = "ls";

	//look up until it is find the folder with all data bases
    for (i = 0; i < 10; i++ ){    // up to then directories up, no more, if need change this
    	// sysTMP = system ( stringLS.c_str() );
    	if ( FileExists( finalPath.c_str() ) != true ){ 		// if in the next directory is not, then add the pat  a ../ and continue
    		pathTmp += upDir;
			finalPath = pathTmp + dirDataSets;
			// stringLS =  "ls -l " + finalPath;
    	}
    	else
    		break; // pathTmp += dirDataSets;
    }



    // it is suppose that the files of the experiment are in the same folder as the name of the TS, with a prefix
    // for classificaiton "class" or  prediciton "pred"


} // End set path of directories


#endif
