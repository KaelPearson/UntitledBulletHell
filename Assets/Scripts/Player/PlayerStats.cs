public static class PlayerStats {
    private static int lifes = 1;
    public static int Lifes {
        get {
            return lifes;
        } set {
            lifes = value;
        }
    }

    private static string gun = "pistol";
    public static string Gun {
        get {
            return gun;
        } set {
            gun = value;
        }
    }

}