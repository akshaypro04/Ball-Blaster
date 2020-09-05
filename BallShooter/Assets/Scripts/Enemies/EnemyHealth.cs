using BallBlast.Comman.Destoy;
using BallBlast.Enemies.ControllerParent;

namespace BallBlast.Enemies.HealthParent
{
    public class EnemyHealth : Destruable
    {

        Enemy m_enemy;
        Enemy enemy
        {
            get
            {
                if (m_enemy == null)
                    m_enemy = GetComponent<Enemy>();
                return m_enemy;
            }
        }


        public override void DamageTake(int amount)
        {
            base.DamageTake(amount);
        }

        public override void die()
        {
            base.die();
        }
    }
}
