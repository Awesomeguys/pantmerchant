using System;
using System.Collections.Generic;
using Color = System.Drawing.Color;
using SwinGameSDK;

namespace PantMerchant
{
    public static class GameResources
    {

        private static void LoadFonts()
        {
            NewFont("Arial", "arial.ttf", 16);
            NewFont("ArialLarge", "arial.ttf", 80);
            NewFont("Courier", "cour.ttf", 14);
            NewFont("CourierSmall", "cour.ttf", 8);
        }

        private static void LoadImages()
        {
            
        }

        private static void LoadSounds()
        {

        }

        private static void LoadMusic()
        {
            NewMusic("Intro", "intro.ogg");
            NewMusic("MainMenu", "mainmenu.ogg");
            NewMusic("InGame", "ingame.ogg");
        }

        /// <summary>
        /// Gets a Font Loaded in the Resources
        /// </summary>
        /// <param name="font">Name of Font</param>
        /// <returns>The Font Loaded with this Name</returns>

        public static Font GameFont(string font)
        {
            return _Fonts[font];
        }

        /// <summary>
        /// Gets an Image loaded in the Resources
        /// </summary>
        /// <param name="image">Name of image</param>
        /// <returns>The image loaded with this name</returns>

        public static Bitmap GameImage(string image)
        {
            return _Images[image];
        }

        /// <summary>
        /// Gets an sound loaded in the Resources
        /// </summary>
        /// <param name="sound">Name of sound</param>
        /// <returns>The sound with this name</returns>

        public static SoundEffect GameSound(string sound)
        {
            return _Sounds[sound];
        }

        /// <summary>
        /// Gets the music loaded in the Resources
        /// </summary>
        /// <param name="music">Name of music</param>
        /// <returns>The music with this name</returns>

        public static Music GameMusic(string music)
        {
            return _Music[music];
        }

        private static Dictionary<string, Bitmap> _Images = new Dictionary<string, Bitmap>();
        private static Dictionary<string, Font> _Fonts = new Dictionary<string, Font>();
        private static Dictionary<string, SoundEffect> _Sounds = new Dictionary<string, SoundEffect>();
        private static Dictionary<string, Music> _Music = new Dictionary<string, Music>();

        public static void LoadResources()
        {
            LoadFonts();
            LoadImages();
            LoadSounds();
            LoadMusic();
        }

        private static void NewFont(string fontName, string filename, int size)
        {
            _Fonts.Add(fontName, SwinGame.LoadFont(SwinGame.PathToResource(filename, ResourceKind.FontResource), size));
        }

        private static void NewImage(string imageName, string filename)
        {
            _Images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(filename, ResourceKind.BitmapResource)));
        }

        private static void NewSound(string soundName, string filename)
        {
            _Sounds.Add(soundName, Audio.LoadSoundEffect(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
        }

        private static void NewMusic(string musicName, string filename)
        {
            _Music.Add(musicName, Audio.LoadMusic(SwinGame.PathToResource(filename, ResourceKind.SoundResource, "music")));
        }

        private static void FreeFonts()
        {
            foreach (Font obj in _Fonts.Values)
            {
                SwinGame.FreeFont(obj);
            }
        }

        private static void FreeImages()
        {
            foreach (Bitmap obj in _Images.Values)
            {
                SwinGame.FreeBitmap(obj);
            }
        }

        private static void FreeSounds()
        {
            foreach (SoundEffect obj in _Sounds.Values)
            {
                Audio.FreeSoundEffect(obj);
            }
        }

        private static void FreeMusic()
        {

            foreach (Music obj in _Music.Values)
            {
                Audio.FreeMusic(obj);
            }
        }

        public static void FreeResources()
        {
            FreeFonts();
            FreeImages();
            FreeMusic();
            FreeSounds();
            SwinGame.ProcessEvents();
        }
    }
}
