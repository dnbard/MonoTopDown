using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoTopDown.GUI;

namespace MonoTopDown.Scenes
{
    class SceneManager
    {
        private static readonly SceneManager Instance = new SceneManager();
        private readonly Game game = Program.Game;
        private readonly SpriteBatch spriteBatch = TopDownGame.SpriteBatch;

        private readonly Dictionary<string, BaseScene> _scenes = new Dictionary<string, BaseScene>();
        private readonly List<IGameComponent> _components = new List<IGameComponent>();

        public BaseScene ActiveScene { protected set; get; }
        public int Count
        {
            get { return _scenes.Count; }
        }

        protected SceneManager()
        {
            _components.Add(new MouseCursor(game));
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
            BaseScene scene;
            Instance._scenes.TryGetValue(sceneName,out scene);
            if (scene != null) Activate(scene);
        }

        public static void Draw(GameTime time)
        {
            if (Instance.ActiveScene == null) return;
            Instance.game.GraphicsDevice.Clear(Color.Black);
            
            Instance.spriteBatch.Begin();

            foreach (IDrawable component in Instance._components.OfType<IDrawable>())
                component.Draw(time);

            Instance.ActiveScene.Draw(time);
            Instance.spriteBatch.End();
        }

        public static void Update(GameTime time)
        {
            if (Instance.ActiveScene == null) return;

            foreach (IUpdateable component in Instance._components.OfType<IUpdateable>())
                component.Update(time);

            Instance.ActiveScene.Update(time);
        }

        public static void DrawLighting(GameTime time)
        {
            if (Instance.ActiveScene == null) return;
            Instance.ActiveScene.DrawLighting(time);
        }
    }
}
