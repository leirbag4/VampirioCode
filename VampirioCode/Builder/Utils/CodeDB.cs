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
                // ------------------------------------
                    return @"//#define SDL_main main

#include <iostream>
#include <SDL2/SDL.h>

using namespace std;

SDL_Window* window;
SDL_Renderer* renderer;


int main(int argc, char** argv[])
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

            }

            return "";

        }
    }
}
