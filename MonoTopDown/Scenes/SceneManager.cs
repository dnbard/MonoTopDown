using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoTopDown.Scenes
{
    class SceneManager
    {
        private static SceneManager Instance = new SceneManager();
        private Game game = Program.Game;

        private Dictionary<string, BaseScene> _scenes = new Dictionary<string, BaseScene>();

        public BaseScene ActiveScene { protected set; get; }
        public int Count
        {
            get { return _scenes.Count; }
        }

        protected SceneManager()
        {
            
        }

        public static void Add(BaseScene scene)
        {
            if (!Instance._scenes.ContainsValue(scene)) 
                Instance._scenes.Add(scene.Name, scene);
        }

        public static void Remove(BaseScene scene)
        {
            Instance._scenes.Remove(scene.Name);
        }

        public static void Remove(string sceneName)
        {
            Instance._scenes.Remove(sceneName);
        }

        public static void Activate(BaseScene scene)
        {
            Add(scene);

            if (Instance.ActiveScene != null) Instance.ActiveScene.Deactivate();
            Instance.ActiveScene = scene;
            Instance.ActiveScene.Activate();
        }

        public static void Activate(string sceneName)
        {
            BaseScene scene = null;
            Instance._scenes.TryGetValue(sceneName,out scene);
            if (scene != null) Activate(scene);
        }

        public static void Draw(GameTime time)
        {
            if (Instance.ActiveScene == null) return;
            Instance.game.GraphicsDevice.Clear(Color.Black);
            Instance.ActiveScene.Draw(time);
        }

        public static void Update(GameTime time)
        {
            if (Instance.ActiveScene == null) return;
            Instance.ActiveScene.Update(time);
        }

        public static void DrawLighting(GameTime time)
        {
            if (Instance.ActiveScene == null) return;
            Instance.ActiveScene.DrawLighting(time);
        }
    }
}
