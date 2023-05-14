import random

# Define the probabilities of each tile type based on player stats
event_prob = 0.1  # Probability of an event tile
quiz_prob = 0.2   # Probability of a quiz tile
note_prob = 0.7   # Probability of a note tile

# Define the player's stats (example values)
intellectual_stats = {
    'scouting_history': 15,
    'founder': 12,
    'general_knowledge': 8,
    'time_management': 18,
    'communication': 6,
    'project_management': 10,
    'cultural_knowledge': 14,
    'environmental_awareness': 16
}
physical_stats = {
    'pioneering': 10,
    'first_aid': 20,
    'emergency_response': 18,
    'cooking': 12,
    'woodsman_ship': 14,
    'camping': 16,
    'estimations': 8,
    'exploration': 6
}

# Define the weights for each stat flavor
stat_flavor_weights = {
    'scouting_history_1': 1,
    'scouting_history_2': 2,
    'founder_1': 1,
    'founder_2': 2,
    # ... and so on for each flavor
}

# Define previously attempted flavors
prev_flavors = []

# Calculate the overall stats based on the player's intellectual and physical stats
overall_stats = sum(intellectual_stats.values()) + sum(physical_stats.values())

# Calculate the probabilities of each tile type based on the overall stats
event_prob *= overall_stats / 1000.0
quiz_prob *= overall_stats / 1000.0
note_prob *= overall_stats / 1000.0

# Generate a random number between 0 and 1 to determine the tile type
rand_num = random.random()

if rand_num < event_prob:
    tile_type = 'event'
elif rand_num < event_prob + quiz_prob:
    tile_type = 'quiz'
else:
    tile_type = 'note'

# Generate a random number between 1 and the number of flavors for the chosen tile type
if tile_type == 'event':
    num_flavors = 10  # Example value
    stat_flavors = [f'event_{i}' for i in range(1, num_flavors+1)]
elif tile_type == 'quiz':
    num_flavors = 15  # Example value
    stat_flavors = [f'quiz_{i}' for i in range(1, num_flavors+1)]
else:
    num_flavors = 20  # Example value
    stat_flavors = [f'note_{i}' for i in range(1, num_flavors+1)]

# Calculate the weights for each stat flavor based on the player's stats
stat_weights = {}
for flavor in stat_flavors:
    stat_name, flavor_num = flavor.split('_')
    if stat_name in intellectual_stats:
        stat_value = intellectual_stats[stat_name]
    else:
        stat_value = physical_stats[stat_name]
    flavor_weight = stat_flavor_weights[f'{stat_name}_{flavor_num}']
    stat_weights[flavor] = stat_value * flavor_weight
    
    # Reduce the chance of having a flavor if the flavor previously attempted
    if flavor in prev_flavors:
        stat_weights[flavor] /= 2  # Reduce the weight by half

# Choose a random stat flavor based on the calculated weights

