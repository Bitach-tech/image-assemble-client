namespace Features.Global.Services.Updaters.Runtime.Abstract
{
    public interface IUpdatable
    {
        void OnUpdate(float delta);
    }
}