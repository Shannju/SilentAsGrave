namespace Script.Mapping
{
    public static class GameConfig
    {
        #region ==== Player State ====

        public const float SpiritDuration = 3f;
        public const float SlipDuration = 3f;
        public const float SlowDuration = 3f;
        public const float LoveDuration = 3f;
        public const float NaughtyToneRadius = 1f;
        public const float NaughtyToneAngle = 90f;

        #endregion

        #region ==== Slap & Skill Cooldown ====

        public const float SlapCooldown = 0.5f;
        public const float SkillCooldown = 0.5f;

        #endregion

        public const float BadWordBulletSpeed = 5f;
        public const float BadWordBulletLifeTime = 15f;
        public const float LoveBulletSpeed = 5f;
        public const float LoveBulletLifeTime = 15f;
    }
}