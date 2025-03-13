# 3D-Flocking-In-Unity
A boid system for flocking birds.

My goal with this project is to create a system of birst that will follow flocking rules to create murmerations. In order to have a large number of birds, I anticipate having to create some kind of data structure to only assess birds that are close to one another. A few years ago I followed a tutorial by The Coding Train (https://www.youtube.com/watch?v=OJxEcs0w_kE) to do this in javascript using a quadtree in 2D. This time I will attempt a 3D scenario.

I sucessfully implemented an Octree structure! Although this did not improve performance over the inbuilt Unity collision detection, it was very satisfying to have written my own collision detection algorithm that was capable of running healthily at a flock of 700 boids. As mentioned in the code, the website https://developer.mozilla.org/en-US/docs/Games/Techniques/3D_collision_detection was very useful in calculating Sphere vs AABB intersections.

For the Octree and collision algorithms there are some visualisation scripts that allow for an interactive scene demonstrating their abilities. I used these scripts for debugging issues but they also ended up being nice ways to visualise what is going on in more abstract situations and going forward I will make more of these types of scenes.
