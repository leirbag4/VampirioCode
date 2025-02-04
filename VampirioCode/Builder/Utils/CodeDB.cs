using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Builder.Utils
{
    public class CodeDB
    {
        public static string GetCode(BuilderTemplate template)
        {
            switch (template)
            {
                // ------------------------------------
                case BuilderTemplate.CppMsvcBasic:
                case BuilderTemplate.CppGnuGppWSLBasic:
                // ------------------------------------

                    return @"#include <iostream>

using namespace std;
    
int main()
{
    cout << ""start"" << endl;
    return 0;   
}";
                // ------------------------------------
                


                // ------------------------------------
                case BuilderTemplate.CppMsvcSDL2:
                case BuilderTemplate.CppGnuGppSDL2:
                // ------------------------------------
                    return @"//#define SDL_main main

#include <iostream>
#include <SDL2/SDL.h>

using namespace std;

SDL_Window* window;
SDL_Renderer* renderer;


int main(int argc, char* argv[])
{
    cout << ""[start]"" << endl;

    //SDL_SetHint(SDL_HINT_WINDOWS_DPI_AWARENESS, ""1"");

    if (SDL_Init(SDL_INIT_VIDEO) < 0)
    {
        cout << ""Can't init video: "" << SDL_GetError() << endl;
    }

    window = SDL_CreateWindow(""Main Window"", SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, 640, 480, SDL_WINDOW_SHOWN | SDL_WINDOW_RESIZABLE);// | SDL_WINDOW_ALLOW_HIGHDPI);

    if (window == nullptr)
    {
        cout << ""Can't create window: "" << SDL_GetError() << endl;
        SDL_Quit();
    }

    renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC);
    
    if (renderer == nullptr)
    {
        cout << ""Can't create renderer: "" << SDL_GetError() << endl;
        SDL_DestroyWindow(window);
        SDL_Quit();
    }

    SDL_SetRenderDrawColor(renderer, 0xFF, 0xFF, 0xFF, 0xFF);
    SDL_RenderClear(renderer);

    SDL_SetRenderDrawColor(renderer, 0xFF, 0, 0, 0xFF);
    SDL_RenderDrawPoint(renderer, 100, 100);

    SDL_Rect rect;
    rect.x = 0;
    rect.y = 0;
    rect.w = 50;
    rect.h = 80;
    SDL_RenderFillRect(renderer, &rect);

    SDL_RenderPresent(renderer);

    SDL_Delay(2000);

    cout << ""[end]"" << endl;

    return 0;
}";
                // ------------------------------------


                // ------------------------------------
                case BuilderTemplate.CppMsvcVampEngine:
                // ------------------------------------
                    return @"//#define SDL_main main

#include <iostream>
#include ""Vamp/Vamp.h""

using namespace std;

void Setup();
void OnInit();
void OnUpdate(float deltaTime);
void OnPaint();

VampEngine* engine;
Texture* texture;

int main(int argc, char* argv[])
{
    engine = new VampEngine();
    engine->OnInit = OnInit;
    engine->OnUpdate =  OnUpdate;
    engine->OnPaint =   OnPaint;
    
    engine->Init();
    engine->Run();
    
    return 0;
}

void OnInit()
{
    
}

void OnUpdate(float deltaTime)
{

}

void OnPaint()
{

    GFX::FillRect(0xFF0000FF, 100, 100, 40, 40);

}


";

                // ------------------------------------
                case BuilderTemplate.CppMsvcVampEngineComplex:
                    // ------------------------------------
                    return @"//#define SDL_main main

#include <iostream>
#include ""Vamp/VampEngine.h""
#include ""Vamp/Key.h""
#include ""Vamp/Keyboard.h""
#include ""Vamp/GFX.h""
#include ""Vamp/Texture.h""
#include ""Vamp/XTimer.h""
#include ""Vamp/Animation.h""
#include ""Vamp/Animator.h""
#include ""Vamp/Sprite.h""
#include ""Vamp/SpriteSheet.h""
#include ""Vamp/Tilemap.h""
#include ""Vamp/Collider.h""
#include ""Vamp/Font.h""
#include ""Vamp/Button.h""
#include ""Vamp/XConsole.h""
#include ""Vamp/Mouse.h""
#include ""Vamp/Scene.h""
#include ""Vamp/Geometry.h""


using namespace std;

void Setup();
void OnInit();
void OnUpdate(float deltaTime);
void OnPaint();

int x = 0;
int y = 0;
bool allowLeft = true;
bool allowRight = true;
bool allowUp = true;
bool allowDown = true;

VampEngine* engine;
Texture* texture;
Tilemap* tilemap;
SpriteSheet* spritesheet;
Animation* animation;
Animation* animation2;
Animator* animator;
Sprite* sprite;
Sprite* sprite2;
Collider* colliderLeft;
Collider* colliderRight;
Collider* colliderUp;
Collider* colliderDown;
Button* button;

int main(int argc, char* argv[])
{
    engine = new VampEngine();
    engine->OnInit = OnInit;
    engine->OnUpdate =  OnUpdate;
    engine->OnPaint =   OnPaint;
    
    XConsole::Println(""[IMPORTANT]: please go first to 'Project/Move Build'. Move the build to any directory. Right click and press 'Open file location' then create a 'res' directory"");
    XConsole::Println(""[IMPORTANT]: at the root of that directory and copy inside 'player_sprite.png', 'tileset.png', 'player_01.png', 'player_02.png', 'player_03.png', 'player_04.png',"");
    XConsole::Println(""[IMPORTANT]: 'cascadia_code.ttf' assets. You can find them at   https://github.com/leirbag4/vamp_engine_vampirio/tree/main/res"");
    XConsole::Println(""[IMPORTANT]: then remove the 'return 0;' code below."");
    return 0;
    
    engine->Init();
    engine->Run();
    
    
    cout << ""start"" << endl;
    return 0;
}

void OnButtonPressed()
{
    XConsole::Println(""button pressed"");
}

void OnInit()
{
	// Textures
    texture = new Texture(""res/player_sprite.png"");
    
    // Tilemap
    tilemap = new Tilemap(""res/tileset.png"", 24, 200, 200, 10, 10);
    tilemap->FillRect(17, 0, 0, 200, 200);
    tilemap->FillRect(16, 4, 4, 8, 8);
    tilemap->FillRect(32, 6, 10, 6, 5);
    tilemap->FillRect(34, 8, 9, 5, 2);
    tilemap->SetTile(34, 5, 5);
    engine->AddChild(tilemap);
    
    // Spritesheet
    spritesheet = new SpriteSheet(texture, 19, 25);
    
    // Animations
    animation = new Animation();
    animation->AddFrame(6);  animation->AddFrame(7);  animation->AddFrame(8);
    animation2 = new Animation();
    animation2->AddFrame(3);  animation2->AddFrame(4);  animation2->AddFrame(5);
    
    // Animator
    animator = new Animator();
    animator->AddAnim(""walk_left"",  animation);
    animator->AddAnim(""walk_right"", animation2);
    
    // Sprites
    sprite = new Sprite();
    sprite->SetSpriteSheet(spritesheet);
    sprite->SetAnimator(animator);
    engine->AddChild(sprite);
    
    sprite2 = new Sprite();
    sprite2->AddFrame(""res/player_01.png"");
    sprite2->AddFrame(""res/player_02.png"");
    sprite2->AddFrame(""res/player_03.png"");
    sprite2->AddFrame(""res/player_04.png"");
    sprite2->Play();
    sprite2->SetPos(130, 75);
    engine->AddChild(sprite2);
    
    // Colliders
    colliderLeft =  new Collider(10, 10);   colliderLeft->SetOffset(-6, +9);    colliderLeft->debug =   true;
    colliderRight = new Collider(10, 10);   colliderRight->SetOffset(+20, +9);  colliderRight->debug =  true;
    colliderUp =    new Collider(10, 10);   colliderUp->SetOffset(+6, -5);      colliderUp->debug =     true;
    colliderDown =  new Collider(10, 10);   colliderDown->SetOffset(+6, +20);   colliderDown->debug =   true;
    
    sprite->AttachCollider(colliderLeft);
    sprite->AttachCollider(colliderRight);
    sprite->AttachCollider(colliderUp);
    sprite->AttachCollider(colliderDown);
    
    // Button
    button = new Button(""res/cascadia_code.ttf"", 12);
    button->SetText(""tester"");
    button->SetPos(40, 200);
    button->SetSize(100, 30);
    button->OnPressed = OnButtonPressed;
    engine->AddChild(button);
    
}

void OnUpdate(float deltaTime)
{
	int speed = 80 * deltaTime;
	
         if(Keyboard::IsDown(Key::UP) && allowUp)       { sprite->y -= speed;   tilemap->localY--; }
    else if(Keyboard::IsDown(Key::DOWN) && allowDown)   { sprite->y += speed;   tilemap->localY++; }
         if(Keyboard::IsDown(Key::LEFT) && allowLeft)   { sprite->x -= speed;   tilemap->localX--; sprite->Play(""walk_left""); }
    else if(Keyboard::IsDown(Key::RIGHT) && allowRight) { sprite->x += speed;   tilemap->localX++; sprite->Play(""walk_right""); }
    
        int blockTile = 34;
    
    allowLeft = !colliderLeft->Collides(tilemap, blockTile);
    allowRight =!colliderRight->Collides(tilemap, blockTile); 
    allowUp =   !colliderUp->Collides(tilemap, blockTile);
    allowDown = !colliderDown->Collides(tilemap, blockTile); 
    
    if(colliderRight->Collides(sprite2))
        engine->RemoveChild(sprite2);
}

void OnPaint()
{
    GFX::FillRect(0xFF0000FF, Mouse::x + 50, Mouse::y - 50, 20, 20);
    GFX::DrawTexture(texture, 300, 100);
    
}


";


                // ------------------------------------
                case BuilderTemplate.CSharpDotnetBasic:
                // ------------------------------------
                    return @"using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(""test"");
    }
}";
                // ------------------------------------

                // ------------------------------------
                case BuilderTemplate.JavascriptBasic:
                // ------------------------------------

                return @"console.log(""tester"")";
                // ------------------------------------

                // ------------------------------------
                case BuilderTemplate.JavaBasic:
                // ------------------------------------

                return @"public class Program
{
    public static void main(String[] args)
    {
        System.out.println(""vampirio"");
    }
}";
                // ------------------------------------


                // ------------------------------------
                case BuilderTemplate.PhpBasic:
                // ------------------------------------

                return @"<?php

    echo(""vampirio"");

?>";
                // ------------------------------------
            

                // ------------------------------------
                case BuilderTemplate.HtmlBasic:
                // ------------------------------------

                return @"<html>
    <head>
        <title>
            Vampirio Page
        </title>
    </head>
    <body>
        <p>
            Vampirio test page
        </p>
    </body>
</html>";
                // ------------------------------------
            }

            return "";



        }
    }
}
