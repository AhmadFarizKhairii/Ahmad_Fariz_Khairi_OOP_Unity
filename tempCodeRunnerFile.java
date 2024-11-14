// Rat.java
import java.util.ArrayList;
import java.util.List;

public class Rat {
    private String name;
    private int level;
    private int health;
    private int maxHealth;
    private int speed;
    private int bitePower;
    private int exp;
    private int expToLevel;
    private List<String> inventory;
    private final int MAX_INVENTORY = 5;

    public Rat(String name) {
        this.name = name;
        this.level = 1;
        this.health = 100;
        this.maxHealth = 100;
        this.speed = 10;
        this.bitePower = 5;
        this.exp = 0;
        this.expToLevel = 100;
        this.inventory = new ArrayList<>();
    }

    public boolean levelUp() {
        if (exp >= expToLevel) {
            level++;
            maxHealth += 20;
            health = maxHealth;
            speed += 2;
            bitePower += 3;
            exp -= expToLevel;
            expToLevel *= 1.5;
            return true;
        }
        return false;
    }

    public boolean eatFood(Food food) {
        if (inventory.size() < MAX_INVENTORY) {
            inventory.add(food.getName());
            health = Math.min(maxHealth, health + food.getHealthRestore());
            exp += food.getExpGain();
            return true;
        }
        return false;
    }

    // Getters and setters
    public String getName() { return name; }
    public int getLevel() { return level; }
    public int getHealth() { return health; }
    public int getMaxHealth() { return maxHealth; }
    public int getExp() { return exp; }
    public int getExpToLevel() { return expToLevel; }
    public List<String> getInventory() { return inventory; }
    public void setHealth(int health) { this.health = health; }
    public void addExp(int exp) { this.exp += exp; }
}

// Food.java
public class Food {
    private String name;
    private int healthRestore;
    private int expGain;
    private int minLevel;

    public Food(String name, int healthRestore, int expGain, int minLevel) {
        this.name = name;
        this.healthRestore = healthRestore;
        this.expGain = expGain;
        this.minLevel = minLevel;
    }

    // Getters
    public String getName() { return name; }
    public int getHealthRestore() { return healthRestore; }
    public int getExpGain() { return expGain; }
    public int getMinLevel() { return minLevel; }
}

// Location.java
import java.util.ArrayList;
import java.util.List;

public class Location {
    private String name;
    private String description;
    private int minLevel;
    private List<String> availableFood;
    private List<String> enemies;
    private List<String> connectedLocations;

    public Location(String name, String description, int minLevel) {
        this.name = name;
        this.description = description;
        this.minLevel = minLevel;
        this.availableFood = new ArrayList<>();
        this.enemies = new ArrayList<>();
        this.connectedLocations = new ArrayList<>();
    }

    // Getters and setters
    public String getName() { return name; }
    public String getDescription() { return description; }
    public int getMinLevel() { return minLevel; }
    public List<String> getAvailableFood() { return availableFood; }
    public List<String> getEnemies() { return enemies; }
    public List<String> getConnectedLocations() { return connectedLocations; }
}

// GameState.java
import java.util.HashMap;
import java.util.Map;

public class GameState {
    private Map<String, Location> locations;
    private Map<String, Food> foods;
    private Rat rat;
    private String currentLocation;

    public GameState() {
        this.locations = new HashMap<>();
        this.foods = new HashMap<>();
        this.currentLocation = "Area Sampah";
    }

    public void initializeGame() {
        // Initialize foods
        foods.put("remah roti", new Food("remah roti", 10, 15, 1));
        foods.put("sisa nasi", new Food("sisa nasi", 20, 25, 1));
        foods.put("keju", new Food("keju", 30, 40, 2));
        foods.put("daging", new Food("daging", 50, 60, 3));
        foods.put("uang kertas", new Food("uang kertas", 100, 100, 5));

        // Initialize locations
        Location sampah = new Location("Area Sampah", 
            "Area awal dengan banyak sampah makanan.", 1);
        sampah.getAvailableFood().add("remah roti");
        sampah.getAvailableFood().add("sisa nasi");
        sampah.getEnemies().add("kecoa");
        sampah.getEnemies().add("tikus kecil");

        Location gang = new Location("Gang Kota",
            "Gang gelap dengan makanan yang lebih bergizi.", 2);
        gang.getAvailableFood().add("keju");
        gang.getAvailableFood().add("sisa nasi");
        gang.getEnemies().add("tikus besar");
        gang.getEnemies().add("kucing liar");

        Location dapur = new Location("Dapur Restoran",
            "Tempat dengan makanan melimpah tapi berbahaya.", 3);
        dapur.getAvailableFood().add("daging");
        dapur.getAvailableFood().add("keju");
        dapur.getEnemies().add("koki");
        dapur.getEnemies().add("perangkap tikus");

        Location kantor = new Location("Perkantoran",
            "Area dengan banyak uang kertas untuk dimakan.", 5);
        kantor.getAvailableFood().add("uang kertas");
        kantor.getEnemies().add("satpam");
        kantor.getEnemies().add("perangkap listrik");

        // Set connections
        sampah.getConnectedLocations().add("Gang Kota");
        gang.getConnectedLocations().add("Area Sampah");
        gang.getConnectedLocations().add("Dapur Restoran");
        dapur.getConnectedLocations().add("Gang Kota");
        dapur.getConnectedLocations().add("Perkantoran");
        kantor.getConnectedLocations().add("Dapur Restoran");

        // Add locations to game state
        locations.put("Area Sampah", sampah);
        locations.put("Gang Kota", gang);
        locations.put("Dapur Restoran", dapur);
        locations.put("Perkantoran", kantor);
    }

    // Getters
    public Map<String, Location> getLocations() { return locations; }
    public Map<String, Food> getFoods() { return foods; }
    public Rat getRat() { return rat; }
    public String getCurrentLocation() { return currentLocation; }
    public void setRat(Rat rat) { this.rat = rat; }
    public void setCurrentLocation(String location) { this.currentLocation = location; }
}

// Game.java
import java.util.Random;
import java.util.Scanner;

public class Game {
    private GameState state;
    private Scanner scanner;
    private Random random;

    public Game() {
        this.state = new GameState();
        this.scanner = new Scanner(System.in);
        this.random = new Random();
    }

    public void startGame() {
        System.out.println("Selamat datang di Adventure De La Rata!");
        System.out.println("==========================================");
        System.out.print("Masukkan nama untuk tikus kamu: ");
        String name = scanner.nextLine();
        
        state.setRat(new Rat(name));
        state.initializeGame();
        
        System.out.println("\nSelamat datang, " + name + " si tikus!");
        gameLoop();
    }

    private void gameLoop() {
        while (true) {
            displayStatus();
            String choice = getPlayerChoice();
            if (choice.equals("q")) {
                System.out.println("Terima kasih telah bermain!");
                break;
            }
            processChoice(choice);
        }
    }

    private void displayStatus() {
        Rat rat = state.getRat();
        Location location = state.getLocations().get(state.getCurrentLocation());
        
        System.out.println("\n" + "=".repeat(50));
        System.out.println("Lokasi: " + state.getCurrentLocation());
        System.out.println(location.getDescription());
        System.out.println("-".repeat(50));
        System.out.println("Status " + rat.getName() + ":");
        System.out.println("Level: " + rat.getLevel() + " | HP: " + 
            rat.getHealth() + "/" + rat.getMaxHealth());
        System.out.println("EXP: " + rat.getExp() + "/" + rat.getExpToLevel());
        System.out.println("Inventory: " + 
            (rat.getInventory().isEmpty() ? "Kosong" : String.join(", ", rat.getInventory())));
        System.out.println("=".repeat(50));
    }

    private String getPlayerChoice() {
        System.out.println("\nApa yang ingin kamu lakukan?");
        System.out.println("1. Cari makanan");
        System.out.println("2. Lihat inventory");
        System.out.println("3. Pindah lokasi");
        System.out.println("4. Istirahat");
        System.out.println("q. Keluar permainan");
        return scanner.nextLine();
    }

    private void processChoice(String choice) {
        switch (choice) {
            case "1" -> searchFood();
            case "2" -> showInventory();
            case "3" -> changeLocation();
            case "4" -> rest();
        }
    }

    private void searchFood() {
        Location location = state.getLocations().get(state.getCurrentLocation());
        
        // Enemy encounter (30% chance)
        if (random.nextDouble() < 0.3) {
            String enemy = location.getEnemies().get(
                random.nextInt(location.getEnemies().size()));
            System.out.println("\nKamu bertemu dengan " + enemy + "!");
            
            // 50% chance to get hurt
            if (random.nextDouble() < 0.5) {
                int damage = random.nextInt(11) + 10; // 10-20 damage
                Rat rat = state.getRat();
                rat.setHealth(rat.getHealth() - damage);
                System.out.println("Kamu terluka dan kehilangan " + damage + " HP!");
                
                if (rat.getHealth() <= 0) {
                    System.out.println("Kamu telah mati! Permainan berakhir.");
                    System.exit(0);
                }
            } else {
                System.out.println("Kamu berhasil menghindar!");
            }
        }

        // Find food (60% chance)
        if (random.nextDouble() < 0.6) {
            List<String> availableFood = location.getAvailableFood();
            if (!availableFood.isEmpty()) {
                String foodName = availableFood.get(random.nextInt(availableFood.size()));
                Food food = state.getFoods().get(foodName);
                
                if (state.getRat().getLevel() >= food.getMinLevel()) {
                    if (state.getRat().eatFood(food)) {
                        System.out.println("\nKamu menemukan " + foodName + "!");
                        System.out.println("+ " + food.getHealthRestore() + " HP");
                        System.out.println("+ " + food.getExpGain() + " EXP");
                        
                        if (state.getRat().levelUp()) {
                            System.out.println("\nSelamat! Level up ke level " + 
                                state.getRat().getLevel() + "!");
                        }
                    } else {
                        System.out.println("\nInventory penuh!");
                    }
                } else {
                    System.out.println("\nKamu menemukan " + foodName + 
                        ", tapi level kamu masih terlalu rendah!");
                }
            } else {
                System.out.println("\nTidak ada makanan di area ini.");
            }
        } else {
            System.out.println("\nKamu tidak menemukan apa-apa...");
        }
    }

    private void showInventory() {
        Rat rat = state.getRat();
        if (rat.getInventory().isEmpty()) {
            System.out.println("\nInventory kosong!");
            return;
        }
        
        System.out.println("\nIsi Inventory:");
        for (String item : rat.getInventory()) {
            Food food = state.getFoods().get(item);
            System.out.println("- " + item + " (Heal: " + food.getHealthRestore() + 
                ", EXP: " + food.getExpGain() + ")");
        }
        
        System.out.print("\nMau makan sesuatu? (tulis nama makanan atau 'tidak'): ");
        String choice = scanner.nextLine();
        
        if (rat.getInventory().contains(choice)) {
            Food food = state.getFoods().get(choice);
            rat.getInventory().remove(choice);
            rat.setHealth(Math.min(rat.getMaxHealth(), 
                rat.getHealth() + food.getHealthRestore()));
            rat.addExp(food.getExpGain());
            
            System.out.println("\nKamu memakan " + choice);
            System.out.println("+ " + food.getHealthRestore() + " HP");
            System.out.println("+ " + food.getExpGain() + " EXP");
            
            if (rat.levelUp()) {
                System.out.println("\nSelamat! Level up ke level " + rat.getLevel() + "!");
            }
        }
    }

    private void changeLocation() {
        Location currentLoc = state.getLocations().get(state.getCurrentLocation());
        System.out.println("\nLokasi yang terhubung:");
        
        List<String> connections = currentLoc.getConnectedLocations();
        for (int i = 0; i < connections.size(); i++) {
            String locName = connections.get(i);
            Location loc = state.getLocations().get(locName);
            System.out.println((i + 1) + ". " + locName + 
                " (Min. Level " + loc.getMinLevel() + ")");
        }
        
        System.out.print("\nPilih nomor lokasi (atau '0' untuk batal): ");
        try {
            int choice = Integer.parseInt(scanner.nextLine());
            if (choice > 0 && choice <= connections.size()) {
                String newLocation = connections.get(choice - 1);
                if (state.getRat().getLevel() >= 
                    state.getLocations().get(newLocation).getMinLevel()) {
                    state