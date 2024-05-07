#include <SFML/Graphics.hpp>
#include <iostream>
using namespace sf;
using namespace std;

int main() {
    RenderWindow window(VideoMode(1000, 800), "Tuff");

    vector<Texture> textures;
    for (int i = 1; i <= 12; ++i) {
        Texture texture;
        if (!texture.loadFromFile("tree" + to_string(i) + ".png")) {
            return EXIT_FAILURE;
        }
        textures.push_back(texture);
    }

    Sprite sprite(textures[0]);
    int currentTextureIndex = 0;
    int clickCount = 0;
    int neededclicks = 3;

    while (window.isOpen()) {
        Event event;
        while (window.pollEvent(event)) {
            if (event.type == Event::Closed) {
                window.close();
            } else if (event.type == Event::MouseButtonPressed) {
                if (event.mouseButton.button == Mouse::Left) {
                    if (event.mouseButton.x > window.getSize().x / 2) {
                        ++clickCount;
                        if (clickCount >= neededclicks) {
                            currentTextureIndex = (currentTextureIndex + 1) % textures.size();
                            sprite.setTexture(textures[currentTextureIndex]);
                            clickCount = 0;
			    neededclicks++;
                        }
                    }
                }
            }
        }

        window.clear();
        window.draw(sprite);
        window.display();
    }

    return EXIT_SUCCESS;
}
