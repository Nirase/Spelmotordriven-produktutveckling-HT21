# Kanvas - Game Design Document<br/>

## Table of Contents
- [1- Design History - Changelog](#history)
- [2- Goals and Vision](#goals-vision)
  - [2.1 Gameplay synopsis](#gameplay-synopsis)
- [3- Audience, Platform, and Marketing](#audience-platform-market)
  - [3.1 Target audience](#target-audience)
  - [3.2 Platform](#platform)
  - [3.3 System requirements](#system-requirements)
  - [3.4 Top performers](#top-performers)
  - [3.5 Feature comparison](#feature-comparison)
  - [3.6 Sales expectations](#sales-expectations)
- [4- Legal Analysis](#legal-analysis)
- [5- Gameplay](#gameplay)
  - [5.1 Overview](#overview)
  - [5.2 Gameplay description](#gameplay-description)
  - [5.3 Controls](#controls)
    - [5.3.1 Interfaces](#interfaces)
  - [5.4 Rules](#rules)
  - [5.5 Game Procedures](#game-procedures)
  - [5.6 Scoring/winning conditions](#score-win-conditions)
  - [5.7 Modes and other features](#modes)
  - [5.8 Levels](#levels)
  - [5.9 Flowchart](#flowchart)
  - [5.10 Editor](#editor)
- [6- Game Characters](#game-characters)
  - [6.1 Character design](#character-design)
  - [6.2 Types](#types)
    - [6.2.1 PCs (player characters)](#player-characters)
    - [6.2.2 NPCs (nonplayer characters)](non-player-characters)
- [7- Story](#story)
  - [7.1 Synopsis](#synopsis)
  - [7.2 Complete story](#complete-story)
  - [7.3 Backstory](#backstory)
  - [7.4 Narrative devices](#narrative-devices)
  - [7.5 Subplots](#subplots)
    - [7.5.1 Subplot #1](#subplot1)
    - [7.5.2 Subplot #2](#subplot2)
- [8- The Game World](#game-world)
  - [8.1 Overview](#overview)
  - [8.2 Key locations](#key-locations)
  - [8.3 Travel](#travel)
  - [8.4 Mapping](#mapping)
  - [8.5 Scale](#scale)
  - [8.6 Physical objects](#physical-objects)
  - [8.7 Weather conditions](#weather-conditions)
  - [8.8 Day and night](#day-and-night)
  - [8.9 Time](#time)
  - [8.10 Physics](#physics)
  - [8.11 Society/ culture](#society-culture)
- [9- Media List](#media-list)
  - [9.1 Interface assets](#interface-assets)
  - [9.2 Environments](#environments)
  - [9.3 Characters](#characters)
  - [9.4 Animation](#animation)
  - [9.5 Music and sound effects](#music-and-sound-effects)
- [10- Technical Specifications](#technical-specifications)
  - [10.1 Technical analysis](#technical-analysis)
    - [10.1.1 New technology](#new-technology)
    - [10.1.2 Major software development tasks](#major-software-development-tasks)
    - [10.1.3 Risks](#risks)
    - [10.1.4 Alternatives](#alternatives)
    - [10.1.5 Estimated resources required](#estimated-resources-required)
  - [10.2 Development platform and tools](#development-platform-and-tools)
    - [10.2.1 Software](#software)
    - [10.2.2 Hardware](#hardware)
  - [10.3 Delivery](#delivery)
    - [10.3.1 Required hardware and software](#required-hardware-and-software)
    - [10.3.2 Required materials](#required-materials)
  - [10.4 Game engine](#game-engine)
    - [10.4.1 Technical specs](#technical-specs)
    - [10.4.2 Design](#design)
    - [10.4.3 Collision detection](#collision-detection)
  - [10.5 Interface technical specs](#interface-technical-specs)
  - [10.6 Controls' technical specs](#controls-technical-specs)
  - [10.7 Lighting models](#lighting-models)
    - [10.7.1 Modes](#modes)
    - [10.7.2 Models](#models)
    - [10.7.3 Light-sources](#light-sources)
  - [10.8 Rendering system](#rendering-system)
    - [10.8.1 Camera](#camera)
  - [10.9 Internet/network spec](#internet-network-spec)
  - [10.10 System parameters](#system-parameters)
    - [10.10.1 Max players](#max-players)
    - [10.10.2 Servers](#servers)
    - [10.10.3 Customization](#customization)
    - [10.10.4 Connectivity](#connectivity)
    - [10.10.5 Websites](#websites)
    - [10.10.6 Persistence](#persistence)
    - [10.10.7 Saving games](#saving-games)
    - [10.10.8 Loading games](#loading-games)
  - [10.11 Other](#other)
    - [10.11.1 Help](#help)
    - [10.11.2 Manual](#manual)
    - [10.11.3 Setup](#setup)

## 1- Design History - Changelog <a name="history"></a>
Include what, when and who changed the GDD for future reference and knowing exactly where to focus when someone else check the document (Use a table). This makes it simple and effortless to track changes to the document.

| V.  | Date       | Description | Author |
|-----|------------|-------------|--------|
| 1.0 | 13/09/2021 | Created the document | Viktor Rydsund |
| 1.1 | 13/09/2021 | Wrote a first draft of 2, 3, 4, 5, 6 and 10 | Mattias Smedman |
| 1.2 | 13/09/2021 | Wrote a first draft of 7 and 8 | Viktor Rydsund |
| 1.3 | 13/09/2021 | Wrote a first draft of 9 | Jonathan Ryytty |
| 1.4 | 26/09/2021 | Reformatted document to markdown | Danny Darwiche |

## 2- Goals and Vision <a name="goals-vision"></a>
Our goal is to create a short and sweet game that takes the player through a journey of discovery through the use of music and colours. We want to create an experience where the player travels through the emotions of sadness, loneliness, friendship and ultimately happiness. We hope to do this through a story without words, told simply through the use of the music, colours, and the world under the ice.

### 2.1 Gameplay synopsis <a name="gameplay-synopsis"></a>
We want to create a very relaxing gameplay loop. The main gameplay loop is simply ice skating without any overwhelmingly complex controls. As the player skates, music will be created through their movement, and the world will react to them based on their input. Through this we hope to create a unique experience.

The game starts off black and white, in the middle of a frozen body of water. The music will be quiet and feel sad, but as the player explores, the world starts to be filled in with colour and the music starts changing. We’re going to aim for a look that reminds people of Ink and Watercolours, we don’t want it to be realistic but we want it to be something that the players can relate to, and that they feel relaxed by.

## 3- Audience, Platform, and Marketing <a name="audience-platform-market"></a>

### 3.1 Target audience <a name="target-audience"></a>
Our target audience is the people who play games a lot more casually. We aren’t aiming at any specific age group, as casual games are becoming increasingly popular even within the age groups that typically play more active games.

We aim to create a game that women can resonate with in some form.

### 3.2 Platform <a name="platform"></a>
We will be developing the game for Windows, Mac and Linux. The reason for this is that Unity natively can build to these platforms without any additional development effort from us.

### 3.3 System requirements <a name="system-requirements"></a>
We’re aiming to have low system requirements as we are not going for very realistic or intensive graphics, though there might be some aspects that require a bit more power from the PC. We have plans to address these performance issues if they come up.

### 3.4 Top performers <a name="top-performers"></a>
ABZU (2016) is one of the best selling games of this type of casual gameplay. In ABZU, you play as a diver swimming alongside aquatic life, and you explore the world that’s under the water directly. While we could not find direct sales figures, it was near the top of the week and month of it’s release on every platform it was released on.

A short hike (2019) is another game that sold very well in a similar genre. In a short hike, the player is tasked with climbing a mountain, and to do so they must interact with the world to unlock new abilities. A short hike also sold very well, doing incredibly well on the Switch compared to how they did on Steam, even though they also did well on Steam.

Journey (2012) is a game that’s known worldwide for its amazing success. In Journey, the player is a robed figure that travels across a vast desert. In Journey there are no words spoken, even though the player can even interact with other players at times. While the exact figures are hard to find, it’s very easy to find that Journey was a very popular game that sold incredibly well on every platform it was released on.

We also took inspiration from The Ramp (2021). The ramp is a simple game where the player plays as a skateboarder on a ramp. While it differs a bit from the previous games, we were inspired by the very simple but catching mechanics of the game. The ramp isn’t nearly as well known as the games mentioned previously, but it is still a game that was well received by those that have played it.

### 3.5 Feature comparison <a name="feature-comparison"></a>
In the first three games mentioned, the player is still actively involved in making events transpire. We aim to create a game where even though the play interacts with the world, it should not feel like the player is in control of the world. Through the use of ice, we have a constant layer between the world that the player is interacting with and the player themself. The colour mechanic is also something that these games do not have. Seeing the world gain colour we hope evokes a feeling of exploration, without the world actually having been changed itself, compared to these games where the world changes because the player is in new areas.

### 3.6 Sales expectations <a name="sales-expectations"></a>
Our current plan is to release this game on Itch, however we’ve been discussing the possibility of releasing this as a commercial game on Steam if it turns out well. We don’t have any specific sales expectations, and would more so be doing it to have had the experience of fully releasing a game on Steam. As the development costs will be minimal, this is an opportune chance to do so.

## 4- Legal Analysis <a name="legal-analysis"></a>
Unity allows for games to be released commercially for free as long as the game is developed by a company that makes less than $100k.

Wwise’s commercial license is a bit unclear, we intend to send an email to them to get clarification for how it works if we decide to make this a commercial game.

Maya’s license does not allow us to sell the game commercially unless we pay for it. We might need to focus on Blender if we decide to go the route of commercially licensing this game.

We will keep the commercial aspect in mind for every asset we might buy.

We will need to check if the name “Kanvas” is a name that we are free to use, however the name is easily changed so this is not a big concern at this moment.

All of this is mainly dependent on how well the game turns out. We want to have a good game that we can point towards and say that we have officially licensed by the time we finish our studies, and this is a good chance for this to happen.

## 5- Gameplay <a name="gameplay"></a>

### 5.1 Overview <a name="overview"></a>
The core gameplay loop is incredibly simple. The game starts off black and white, and the player moves on the ice through skating, possibly through the use of matching a rhythm, and as they explore the world they will encounter wild life, typically that lives under the ice, that they can sync up with to create unique events. After triggering a big event, the player will unlock the ability to see a new colour.

![Gameplay](https://drive.google.com/uc?export=view&id=1BFIyZmLKUMcRTxv-Z7jZ3JtbRwBXypP6)

### 5.2 Gameplay description <a name="gameplay-description"></a>
As the player moves through the world, they will encounter different events. The player will need to interact with these events through various means. The ways to interact with the events is the following ways:

Leading a fish from one point to another. Helping the fish find its way back to it’s school makes the fish swim happily in a way that knocks something over, which releases a colour back into the world.

The player has to match the pattern that fish are swimming in to make them move in a certain way.

The player has to move over certain areas of the ice that play unique sounds whenever the player is on them to wake up a sleeping animal.

The player has to follow a fish that tries to run away from her.

The player has to help a crab get through a maze by swimming above it while following the pattern of the maze.

### 5.3 Controls <a name="controls"></a>
The full controls are still undecided. We’re planning on trying a few different versions to find which works the best for a relaxing game.

The controller we are the most interested in is one where you have to press keys in a certain rhythm to move forward, however we are conscious of how it might make the game feel more stressful than it should. An example of this is to use A and D to alternate between which leg you’re using to move, and using left and right arrow keys to turn, and the player has to alternate A and D to a rhythm.

![Controls](https://drive.google.com/uc?export=view&id=1KgBTJAzdxnHzwy2c-fG0bcggU_Q6oTln)

Another version is where instead of the player having to match a rhythm in their movement, we instead just have the animations and sounds from hitting the ice match a rhythm. This takes out a lot of the gameplay from moving around, where we instead just let the player move freely through the use of WASD, however it might lead to a much more relaxing gameplay feel.

#### 5.3.1 Interfaces <a name="interfaces"></a>
Main Menu Example:

![MainMenu](https://drive.google.com/uc?export=view&id=1PG7Oyxe07W6tfUmoL7jBdFJYS293GUHi)

In the main menu, the player only has three different choices. They can either start the game, change the settings, or quit. We might possibly add a load feature if the game ends up being longer than ~1 hour.

While the game is running, there isn’t actually any interface or UI. The player has no resource or information that they need to track, so we’re leaving the in-game screen as clean as possible, so that there’s more space for the player to look at the world.

### 5.4 Rules <a name="rules"></a>
If you have created a prototype, describing the rules of your game will be much easier. You will need to define all the game objects, concepts, their behaviors, and how they relate to one another in this section.

The player only has black and white colours at the start of the game.

The player unlocks more colours as they complete various events. These events will be filled in here as the game is developed:
- The player can swim over specific parts of the ice to play sounds. These sounds will trigger events when played in the right order.
- Certain fish will follow the player to a location. If the player strays too far from the goal while guiding the fish will swim back to its original location.
- The player has to swim in specific patterns to match with the fish.

The player has no way of directly interacting with the wild life, as in they can not touch it. Any interaction they have will be distant.

Wildlife fish will be swimming around under the ice for the player to look at. Most of these will be swimming aimlessly.

If the player gets lost or does not make progress for a certain amount of time, a noticeable fish will help guide the player towards their goal.

### 5.5 Game Procedures <a name="game-procedures"></a>
The player wakes up, with no colours unlocked. They explore the ice and find one of a few events, finishing it will unlock a new colour. Once they’ve done this for all the events, the game is finished.

### 5.6 Scoring/winning conditions <a name="score-win-conditions"></a>
The win condition of the game happens when the player has finished all the major events and they have unlocked all the colours. When they’ve done this, the game will trigger an ‘end scene’ event that will be a drastic encounter that makes the player lose all their colours again for a short while. Once they get them all back to a short impactful moment, the game will end.

### 5.7 Modes and other features <a name="modes"></a>
After the game has ended the player is free to skate around on the ice.

### 5.8 Levels <a name="levels"></a>
The designs for each level should be laid out here. The more detailed the better.

### 5.9 Flowchart <a name="flowchart"></a>
Create a flowchart showing all the areas and screens that will need to be created.

Below is the basic outline of how we imagine the game world. The world is open, meaning that each section of the map is accessible from the get-go. Each area has a subset of meaningful interactions.

The following is an example of how such an event might be structured:

EX) **Section A**: Has the interaction of guiding a single lost red fish back to the school of fish with the corresponding color. Doing this will unlock the color “Red” and the accompanying music.

**Section E**: This is the final area of the game. When all other areas have been completed the end event happens here

![WorldLayout](https://drive.google.com/uc?export=view&id=1LcCZqW5GkJ2moDL5mDXKRCWWynhtrk5-)

### 5.10 Editor <a name="editor"></a>

## 6- Game Characters <a name="game-characters"></a>
This is where you describe any game characters and their attributes.

### 6.1 Character design <a name="character-design"></a>
The character is a woman who wakes up alone on the ice. We’re going for a watercolour and ink feel on everything, so they will have clear defined lines, and when colours are all in the world again they  will be colourful.

### 6.2 Types <a name="types"></a>

#### 6.2.1 PCs (player characters) <a name="player-characters"></a>
Our player character has no attributes that they need to keep track of. It’ll simply be just a character that you can move around freely.

#### 6.2.2 NPCs (non-player characters) <a name="non-player-characters"></a>
If your game involves character types, you will need to treat each one as an object, defining its properties and functionality.

Our game has no NPCs that the player talks to interacts with, but there will be a large amount of NPC animals. Each unique animal will get a subsection here that explains their purpose:

##### 6.2.2.1 Behavior
If the artificial intelligence is an important component of your project since the NPCs have a set of complex intertwined systems, you should open a subsection or whole section only for it.
We will be utilizing a few versions of AI to create a natural feeling wildlife. Most of the fish will be controlled through Boids, so that they appear to be moving around naturally. Some of the other fishes will use pathfinding and behaviour trees to make sure that they’re more noticeable, but still feel natural.

## 7- Story <a name="story"></a>

### 7.1 Synopsis <a name="synopsis"></a>
A lost ice-skater befriends a fish and restores colour and music to the world. The fish dies and the protagonist becomes sad. Later the fish is revealed to be alive and the world becomes vibrant again.

### 7.2 Complete story <a name="complete-story"></a>
This is your chance to outline the entire story. Do not just tell the story, structure it as it will unfold in the gameplay and try to follow the dramatic arcs presented in class.

**Chapter 1**:

The basic premise of the story is as follows: The polar ice caps have melted and the world has been flooded. A new ice age begins and the ocean is frozen yet again. Leaving only the tip of once recognizable landmarks above the heavy curtain of ice.

Lost and frozen our protagonist wakes up with no memories of events prior. As the protagonist fully wakes up it dawns that something is amiss. The “colours of music” are long gone leaving only a black and white silhouette.

Wandering the desolated planes of ice our protagonist crosses paths with seemingly the only other life around. A little red fish. This strange meeting does not go as planned as the red fish initially is avoidant of any interaction.

. . .

Note: - Below are writing prompts used to plot out key happenings in the story.

**Chapter 2**:

As our protagonist learns more of the world she understands that through ice-skating the world can be altered.

**Chapter ?**:

The little red fish who now has become a friend in need dies. The death of the fish launches our protagonist back into a cycle of hopelessness as the “colours of music” fade once more.

**Ending**:

Suddenly powerful rhythmic thuds can be felt as the ice shakes. The thuds seem to hint at our protagonist, urging her to follow and investigate. Following the thuds to its source it becomes clear that our friend the red fish survived. This reveal makes our protagonist so happy the “colors of music” return.

### 7.3 Backstory <a name="backstory"></a>
Describe any important elements of your story that do not tie directly into the gameplay. For instance, the backstory of how the dwarfs found ancient weapons and as such they dominate the region. It does not need to make it to the actual game but it is good as reference.

As mentioned, the story takes place on a large frozen over sea. In this story the presence of music and colours are tied together. Meaning music has a dimension of form and colour.

### 7.4 Narrative devices <a name="narrative-devices"></a>
Describe the various ways in which you plan to reveal the story. What are the devices you plan to use to tell the story?

The story is never told explicitly but instead via exploration and interaction with the environment. Ice being see-through lends itself to telling stories under the ice.

### 7.5 Subplots <a name="subplots"></a>
Since games do not need to be linear, there might be numerous smaller stories interwoven into the main story. Describe each of these subplots and explain how they tie into the gameplay and the master plot.

#### 7.5.1 Subplot #1 <a name="subplot1"></a>
Our protagonist encounters a ginormous eye frozen solid near the surface of the ice. Later as colour is restored the eye opens and the iris starts looking around. This orca is later responsible for the loud thuds guiding our player back to the red fish.

#### 7.5.2 Subplot #2 <a name="subplot2"></a>
tbd

## 8- The Game World <a name="game-world"></a>
If your game involves the creation of a world, you may want to go into detail on all aspects of that world. If world creation is a main mechanic of your game as for instance, Carcassonne, you should write about it in the gameplay section and here you have all the reserved space to go into very specific information about it.

### 8.1 Overview <a name="overview"></a>
A world covered in ice, a vast frozen sea with remnants of a world past.

### 8.2 Key locations <a name="key-locations"></a>
Five key locations, four of them that all need to be completed to unlock the final event.

![WorldLayout](https://drive.google.com/uc?export=view&id=1LcCZqW5GkJ2moDL5mDXKRCWWynhtrk5-)

### 8.3 Travel <a name="travel"></a>
Travel will be done through skating. No fast travel.

### 8.4 Mapping <a name="mapping"></a>
Open world, divided into five zones each containing a key location.

### 8.5 Scale <a name="scale"></a>
It will take the player a few minutes to skate the map border to border.

![Scale](https://drive.google.com/uc?export=view&id=19QiKrK1m9Q1xP4fSWk1TFuvbHgDKJ4x5)

### 8.6 Physical objects <a name="physical-objects"></a>
None.

### 8.7 Weather conditions <a name="weather-conditions"></a>
There will be weather, it is not decided if this will affect the player or not. Examples of weather conditions that will be implemented are: snow, wind and rain.

### 8.8 Day and night <a name="day-and-night"></a>
TBD

### 8.9 Time <a name="time"></a>
Real time.

### 8.10 Physics <a name="physics"></a>
Real life physics (more or less).

### 8.11 Society/culture <a name="society-culture"></a>
Seemingly the only person left alive.

## 9- Media List <a name="media-list"></a>
Any type of digital asset that you will be using should be placed here.

### 9.1 Interface assets <a name="interface-assets"></a>

### 9.2 Environments <a name="environments"></a>
https://assetstore.unity.com/packages/3d/environments/landscapes/stylized-ice-formations-163302

https://assetstore.unity.com/packages/3d/environments/stylized-nature-pack-37457

https://assetstore.unity.com/packages/3d/vegetation/story-northern-nature-164556

https://blenderartists.org/t/black-and-white-comic-book-materials-cycles/645066

### 9.3 Characters <a name="characters"></a>

### 9.4 Animation <a name="animation"></a>
https://assetstore.unity.com/packages/3d/animations/toon-ice-skating-animations-134707

### 9.5 Music and sound effects <a name="music-and-sound-effects"></a>
List all of the media that will need to be produced. The specifics of your game will dictate what categories you need to include. Be detailed with this list, and create a file naming convention up front. This can avoid a lot of confusion later on.

## 10- Technical Specifications <a name="technical-specifications"></a>

### 10.1 Technical analysis <a name="technical-analysis"></a>

#### 10.1.1 New technology <a name="new-technology"></a>
Is there any new technology that you plan on developing for this game? If so, describe it in detail.

#### 10.1.2 Major software development tasks <a name="major-software-development-tasks"></a>
We are using a preexisting game engine to make the development process easier. We will be developing through Unity.

The only major software that we need to develop is a tool that will help the process. We will be developing a tool that...

#### 10.1.3 Risks <a name="risks"></a>
What are the risks inherent in your strategy?

#### 10.1.4 Alternatives <a name="alternatives"></a>
Are there any alternatives that can lower the risks and the cost?

#### 10.1.5 Estimated resources required <a name="estimated-resources-required"></a>
Describe the resources you would need to develop the new technology and software needed for the game.

### 10.2 Development platform and tools <a name="development-platform-and-tools"></a>
Describe the development platform, as well as any software tools and hardware that are required to produce the game.

#### 10.2.1 Software <a name="software"></a>
- Github - Used as version control and as a way for us to organize all our work.
- Maya & Blender - Used to create 3D Models.
- Unity - Used as a game engine for the entire process.

#### 10.2.2 Hardware <a name="hardware"></a>

### 10.3 Delivery <a name="delivery"></a>
How do you plan to deliver this game? Over the Internet? Via an app service? At a brick-and-mortar location? What is required to accomplish this?

The game will be delivered through some online game publishing website. It’ll either be through Itch as a free game or through Steam as a paid one.

#### 10.3.1 Required hardware and software <a name="required-hardware-and-software"></a>

#### 10.3.2 Required materials <a name="required-materials"></a>

### 10.4 Game engine <a name="game-engine"></a>

#### 10.4.1 Technical specs <a name="technical-specs"></a>
What are the specs of your game engine?

#### 10.4.2 Design <a name="design"></a>
Describe the design of your game engine.

#### 10.4.3 Collision detection <a name="collision-detection"></a>
If your game involves collision detection, how does it work?

### 10.5 Interface technical specs <a name="interface-technical-specs"></a>
This is where you describe how your interface is designed from a technical perspective. What tools do you plan to use, and how will it function?

### 10.6 Controls' technical specs <a name="controls-technical-specs"></a>
This is where you describe how your controls work from a technical perspective. Are you planning on supporting any unusual input devices that would require specialized programming?

### 10.7 Lighting models <a name="lighting-models"></a>
Lighting can be a substantial part of a game. Describe how it works and the features that you require.

#### 10.7.1 Modes <a name="modes"></a>

#### 10.7.2 Models <a name="models"></a>

#### 10.7.3 Light sources <a name="light-sources"></a>

### 10.8 Rendering system <a name="rendering-system"></a>

#### 10.8.1 Camera <a name="camera"></a>

### 10.10 System parameters <a name="system-parameters"></a>

#### 10.10.1 Max players <a name="max-players"></a>
1

#### 10.10.2 Servers <a name="servers"></a>
None.

#### 10.10.3 Customization <a name="customization"></a>
None.

#### 10.10.4 Connectivity <a name="connectivity"></a>
None.

#### 10.10.5 Websites <a name="websites"></a>
None.

#### 10.10.6 Persistence <a name="persistence"></a>
None.

#### 10.10.7 Saving games <a name="saving-games"></a>
Possibly.

#### 10.10.8 Loading games <a name="loading-games"></a>

### 10.11 Other <a name="other"></a>

#### 10.11.1 Help <a name="help"></a>

#### 10.11.2 Manual <a name="manual"></a>

#### 10.11.3 Setup <a name="setup"></a>