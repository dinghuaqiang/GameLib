namespace UnityEngine
{
    public static class GoTransExtension
    {
        public static Comp RequireComponent<Comp>(this Transform transInst) where Comp : Component
        {
            var comp = transInst.GetComponent<Comp>();
            if (comp == null)
            {
                comp = transInst.gameObject.AddComponent<Comp>();
            }
            return comp;
        }

        public static Comp RequireComponent<Comp>(this GameObject go) where Comp : Component
        {
            var comp = go.GetComponent<Comp>();
            if (comp == null)
            {
                comp = go.AddComponent<Comp>();
            }
            return comp;
        }
    }
}
