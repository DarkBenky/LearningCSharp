using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

class Program
{   
    class Particle {
        public float x;
        public float y;
        public float xVelocity;
        public float yVelocity;
        public float mass;
        public float radius;
        public Color color;

        public Particle(float x, float y, float xVelocity, float yVelocity, float mass, float radius) {
            this.x = x;
            this.y = y;
            this.xVelocity = xVelocity;
            this.yVelocity = yVelocity;
            this.mass = mass;
            this.radius = radius;
            // Generate a random color for each particle
            Random rand = new Random();
            this.color = Color.FromArgb(rand.Next(50, 200), rand.Next(50, 200), rand.Next(50, 200));
        }
    }

    class BoundingBox {
        public float minX;
        public float minY;
        public float maxX;
        public float maxY;

        public BoundingBox(float minX, float minY, float maxX, float maxY) {
            this.minX = minX;
            this.minY = minY;
            this.maxX = maxX;
            this.maxY = maxY;
        }
    }

    class ParticleSystem {
        public Particle[] particles;
        public int particleCount;
        public BoundingBox boundingBox;

        public ParticleSystem(int maxParticles) {
            particles = new Particle[maxParticles];
            particleCount = 0;
        }

        public void AddParticle(float x, float y, float xVelocity, float yVelocity, float mass, float radius) {
            if (particleCount < particles.Length) {
                particles[particleCount] = new Particle(x, y, xVelocity, yVelocity, mass, radius);
                particleCount++;
            } else {
                Console.WriteLine("Particle system is full");
                // resize or handle overflow
                Particle[] tempParticles = new Particle[particles.Length * 2];
                Array.Copy(particles, tempParticles, particles.Length);
                particles = tempParticles;
                particles[particleCount] = new Particle(x, y, xVelocity, yVelocity, mass, radius);
                particleCount++;
                Console.WriteLine("Particle added after resizing");
            }
        }

        public void Update(float deltaTime) {
            for (int i = 0; i < particleCount; i++) {
                Particle p = particles[i];
                p.x += p.xVelocity * deltaTime;
                p.y += p.yVelocity * deltaTime;

                // check for boundary collisions
                if (p.x - p.radius < boundingBox.minX) {
                    p.xVelocity = Math.Abs(p.xVelocity); // Reflect velocity
                    p.x = boundingBox.minX + p.radius;
                } else if (p.x + p.radius > boundingBox.maxX) {
                    p.xVelocity = -Math.Abs(p.xVelocity); // Reflect velocity
                    p.x = boundingBox.maxX - p.radius;
                }
                
                if (p.y - p.radius < boundingBox.minY) {
                    p.yVelocity = Math.Abs(p.yVelocity); // Reflect velocity
                    p.y = boundingBox.minY + p.radius;
                } else if (p.y + p.radius > boundingBox.maxY) {
                    p.yVelocity = -Math.Abs(p.yVelocity); // Reflect velocity
                    p.y = boundingBox.maxY - p.radius;
                }

                // Check for collisions with other particles
                for (int j = i + 1; j < particleCount; j++) {
                    Particle other = particles[j];
                    float dx = other.x - p.x;
                    float dy = other.y - p.y;
                    float distanceSquared = dx * dx + dy * dy;
                    float radiusSum = p.radius + other.radius;

                    if (distanceSquared < radiusSum * radiusSum) {
                        HandleCollision(p, other);
                    }
                }
            }
        }

        private void HandleCollision(Particle p1, Particle p2) {
            // Simple elastic collision response
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);
            float overlap = p1.radius + p2.radius - distance;

            if (overlap > 0) {
                // Move particles apart
                float nx = dx / distance;
                float ny = dy / distance;
                p1.x -= nx * overlap / 2;
                p1.y -= ny * overlap / 2;
                p2.x += nx * overlap / 2;
                p2.y += ny * overlap / 2;

                // Calculate new velocities
                float relativeVelocityX = p1.xVelocity - p2.xVelocity;
                float relativeVelocityY = p1.yVelocity - p2.yVelocity;
                float dotProduct = relativeVelocityX * nx + relativeVelocityY * ny;

                if (dotProduct < 0) {
                    return; // Already separating
                }

                // Update velocities based on mass
                float coefficientOfRestitution = 0.8f; // Adjust for energy loss
                float impulse = (-(1 + coefficientOfRestitution) * dotProduct) / (1 / p1.mass + 1 / p2.mass);
                p1.xVelocity += impulse * nx / p1.mass;
                p1.yVelocity += impulse * ny / p1.mass;
                p2.xVelocity -= impulse * nx / p2.mass;
                p2.yVelocity -= impulse * ny / p2.mass;
            }
        }
    }

    class Simulation {
        private ParticleSystem particleSystem;
        private float deltaTime;
        private Random rand;

        public Simulation(int maxParticles, float deltaTime, BoundingBox boundingBox) {
            particleSystem = new ParticleSystem(maxParticles);
            this.deltaTime = deltaTime;
            this.particleSystem.boundingBox = boundingBox;
            this.rand = new Random();
        }

        public void AddParticleRandomly() {
            float x = (float)(rand.NextDouble() * (particleSystem.boundingBox.maxX - particleSystem.boundingBox.minX) + particleSystem.boundingBox.minX);
            float y = (float)(rand.NextDouble() * (particleSystem.boundingBox.maxY - particleSystem.boundingBox.minY) + particleSystem.boundingBox.minY);
            float xVelocity = (float)(rand.NextDouble() * 2 - 1) * 50;
            float yVelocity = (float)(rand.NextDouble() * 2 - 1) * 50;
            float mass = 10.0f;
            float radius = 5.0f + (float)(rand.NextDouble() * 10);
            AddParticle(x, y, xVelocity, yVelocity, mass, radius);
        }

        public void AddParticle(float x, float y, float xVelocity, float yVelocity, float mass, float radius) {
            particleSystem.AddParticle(x, y, xVelocity, yVelocity, mass, radius);
        }

        public void Update() {
            particleSystem.Update(deltaTime);
        }
        
        public ParticleSystem GetParticleSystem() {
            return particleSystem;
        }
    }
    
    class ParticleRenderer : Form {
        private Simulation simulation;
        private Timer timer;
        private const int FPS = 60;
        
        public ParticleRenderer(Simulation simulation) {
            this.simulation = simulation;
            
            this.DoubleBuffered = true;
            this.Width = 800;
            this.Height = 600;
            this.Text = "Particle Simulation";
            
            timer = new Timer();
            timer.Interval = 1000 / FPS;
            timer.Tick += (sender, e) => {
                simulation.Update();
                this.Invalidate();
            };
            timer.Start();
            
            this.Paint += ParticleRenderer_Paint;
            this.KeyDown += ParticleRenderer_KeyDown;
        }
        
        private void ParticleRenderer_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            
            // Clear background
            g.Clear(Color.Black);
            
            // Draw boundary
            BoundingBox box = simulation.GetParticleSystem().boundingBox;
            g.DrawRectangle(Pens.White, box.minX, box.minY, box.maxX - box.minX, box.maxY - box.minY);
            
            // Draw particles
            ParticleSystem particleSystem = simulation.GetParticleSystem();
            for (int i = 0; i < particleSystem.particleCount; i++) {
                Particle p = particleSystem.particles[i];
                using (SolidBrush brush = new SolidBrush(p.color)) {
                    g.FillEllipse(brush, p.x - p.radius, p.y - p.radius, p.radius * 2, p.radius * 2);
                }
                g.DrawEllipse(Pens.White, p.x - p.radius, p.y - p.radius, p.radius * 2, p.radius * 2);
            }
            
            // Display stats
            g.DrawString($"Particles: {particleSystem.particleCount}", 
                new Font("Arial", 10), Brushes.White, new PointF(10, 10));
        }
        
        private void ParticleRenderer_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space) {
                simulation.AddParticleRandomly();
            } else if (e.KeyCode == Keys.Escape) {
                Application.Exit();
            }
        }
    }

    [STAThread]
    static void Main(string[] args)
    {
        // Create a simulation with a bounding box
        BoundingBox box = new BoundingBox(50, 50, 750, 550);
        Simulation simulation = new Simulation(100, 1.0f/60.0f, box);
        
        // Add some initial particles
        for (int i = 0; i < 200; i++) {
            simulation.AddParticleRandomly();
        }
        
        // Create and run the renderer
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new ParticleRenderer(simulation));
    }
}