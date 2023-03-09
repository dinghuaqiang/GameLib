using System.Text;
using UnityEngine;

namespace Assets.Test.AssemblyTest
{
    public class UpdateManager
    {
        public static void Start(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            if (args != null)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    builder.Append(args[i]);
                }
                Debug.Log(builder.ToString());
            }
        }

        public void QuickStart(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            if (args != null)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    builder.Append(args[i]);
                }
                Debug.Log(builder.ToString());
            }
        }

        private void PrivateStart(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            if (args != null)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    builder.Append(args[i]);
                }
                Debug.Log(builder.ToString());
            }
        }
    }
}
