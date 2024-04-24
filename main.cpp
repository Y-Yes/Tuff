#include <SFML/Graphics.hpp>
using namespace sf;

int main(){
	//Creating the window
	RenderWindow window(VideoMode(1000, 800), "Tuff");
	//While the window is open
	while(window.isOpen()){
	Event event;
	Texture texture;

	if(!texture.loadFromFile("tree.png")) //Checks if the file exists
		return EXIT_FAILURE;
	Sprite sprite(texture);
		while (window.pollEvent(event)){
			if(event.type==sf::Event::Closed){
				window.close(); //If you close the window stop the game
			}
		}
	window.clear();
	window.draw(sprite); //Draws the tree
	window.display();
	}
	return EXIT_SUCCESS;
}
