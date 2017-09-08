/*File to test the C_network class
 * Created 25/11/09
 * Carlos Torres and Victor Landassuri
 */



#include "testNetwork.hpp"  //to load some global variables, similar to EPNet
#include "C_network.hpp"

using namespace ANNs;

int main()
{
    C_network *network;
	network = new C_network;
	// I need to initilize all its parameters
    
		
	network->Epochs->init(&epochsK[1]);
	network->Epochs->print();
	
}
