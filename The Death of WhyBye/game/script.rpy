# The script of the game goes in this file.

# Declare characters used by this game. The color argument colorizes the
# name of the character.

define a = Character("Amber")


# The game starts here.

label start:

    # Show a background. This uses a placeholder by default, but you can
    # add a file (named either "bg room.png" or "bg room.jpg") to the
    # images directory to show it.

    scene bg room

    # This shows a character sprite. A placeholder is used, but you can
    # replace it by adding a file named "eileen happy.png" to the images
    # directory.

    show eileen happy

    # These display lines of dialogue.

    a "Hi there!"
    a "I'm currently speaking as a representation of Amber, who participated in Daydream Brighton on the 27th September 2025."
    "Wait, why isn't Amber here?"
    a "During this event, Amber and Sean created a game called WhyBye in Unity. This game was going great and they knew it would easily win the grand prize"
    "This isn't what was supposed to happen..."
    
    scene bg boonity
    
    "Oh dear.... what's that?"
    
    a "That is our project. Failing to run."
    a "We believe that it failed due to a combination of how Unity handles assets and my bad code"
    
    scene bg sysdata
    
    a "Look at that..."
    
    scene bg resources
    
    a "And that too!"
    
    "Wow."
    
    scene bg commits
    
    a "I never want to touch this project again."
    a "I want to burn this project"
    a "Torch it"
    a "SACRIFICE IT!!!!!!!!!"
    "Woah, woah, calm down there!"
    
    a "And this is the story of how WhyBye was no more :D"
    

    # This ends the game.

    return
