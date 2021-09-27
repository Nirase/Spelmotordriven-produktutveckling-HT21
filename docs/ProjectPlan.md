# Kanvas - Project Plan<br/>
### Group 1
### V. 1.5
### 2021/09/26

<br/>

## Table of Contents
- [Versions](#versions)
- [Project Plan](#project-plan)
  - [Gantt Chart](#gantt-chart)
- [Team Composition](#team)
- [Tools and technical](#tools-tech)
  - [GitHub](#github)
  - [Discord](#discord)
  - [Unity](#unity)
  - [Wwise](#wwise)
  - [Maya & Blender](#maya-blender)
  - [Krita](#krita)
  - [Google Documents](#google-docs)
- [Methodology](#method)
  - [Planned Meetings](#planned-meetings)
  - [Sprints](#sprints)
- [Risk Analysis](#risk-analysis)
  - [Identified Risks](#identified-risks)
    - [#1 Character Controller ends up clunky](#character-controller)
    - [#2 Underestimation of how much work the colour mechanic is](#color-mechanic)
    - [#3 Git Issues](#git-issues)
    - [#4 Sickness](#sickness)
    - [#5 Sound Issues](#sound)
    - [#6 Performance](#performance)
    - [#7 Underestimation of shader work](#shaders)
    - [\<id> \<Namn på risk>](#placeholder1)
    - [\<id> \<Namn på risk>](#placeholder2)
- [Risk Diagram](#risk-diagram)

## Versions <a name="versions"></a>
| V. | Date | Description | Author |
|---|---|---|---|
| 1.1 | 9/13 | Pre-production preliminary | Jonathan Ryytty |
| 1.2 | 9/13 | Added time plan | M. Smedman, J. Ryytty, I. Nyström, D. Darwiche, V. Rydsund |
| 1.3 | 9/13 | Added and filled in Methodology, Team Composition, Tools and Risks (#1, #2, #3, #4 and #5) and added a risk diagram | Mattias Smedman |
| 1.4 | 9/13 | Added Risks #6 and #7 | M. Smedman, I. Nyström |
| 1.5 | 9/26 | Reformated to markdown | Danny Darwiche |

## Project Plan <a name="project-plan"></a>

### Gantt Chart <a name="gantt-chart"></a>

![Gantt Chart](https://user-images.githubusercontent.com/62639702/134802678-644b69b8-7b21-40d2-bb35-99b788fd90ab.png)

It’s important to note that the most important dates on the board are the Due Dates. As we have other courses to work on, we do not have the time to spend every day working on the project. As long as the task is completed at the due date, we are following the schedule. Once we are done with pre-production, a similar plan will be created for the production phase as well.

## Team Composition <a name="team"></a>

| Team Member     | Lead Role |
|-----------------|-----------|
| Mattias Smedman | Team Leader, Lead programmer |
| Isak Nyström    | Lead Technical Artist |
| Jonathan Ryytty | Lead 3D Artist |
| Viktor Rydsund  | Lead Animator |
| Danny Darwiche  | Lead Level Design |

While we do not expect that we would need to have a lead role for all these aspects or even for any of them, as we are a small group, we decided to make sure that we list one person as the lead for every area we could think of. This is just in the case that we are in a situation where we can not come to a group decision, it is good to have one person that can be pointed towards as the person that makes the final decision. Deciding this ahead of time means that we will not be in a situation where we are unsatisfied in the future, we all have the same expectation that if necessary, our opinion could get overruled for the sake of the project as a whole.

## Tools and technical <a name="tools-tech"></a>

### GitHub <a name="github"></a>
Github will be used for version control as well as for general project planning. We will be utilizing the Github Projects Board as Kanban boards, so that we have a clear picture of who is doing what or when something has been done. We will also have a column for “Ungroomed” ideas, where we place any ideas that we come up with but have not ironed out the details for yet. Through creating Issues based on the project board we can automate the process of marking things as done or as work in progress. Combining the kanban board and version control makes it easier for us to make sure that the kanban board is always up to date, and also makes it easier for us to manage the git history.

The project is going to be split into three different boards. There will be one for Pre-Production, one for Production and one for Documentation. If we end up in a situation with a lot of bugs during QA, we might create a board for bugs as well depending on how many we have.

### Discord <a name="discord"></a>
Discord will be used for all of our meetings. Through this we can share our screens so that we can easily show others what we have done, or if we need to draw something to convey ideas more easily to each other we can do so as well.

### Unity <a name="unity"></a>
We will be developing the game using Unity. This means that the game will be developed in C#, and it lets us utilize their Shader graph technology, which means that the shaders we create will be done mainly through visual scripting. This makes the process for developing the game far easier, as we are relying on shaders for a lot of various aspects.

### Wwise <a name="wwise"></a>
The plan is to use Wwise to connect Unity and the Sound design together.

### Maya & Blender <a name="maya-blender"></a>
We will be using both Blender and Maya for any 3D modelling that we need to do. We are using both of them as the team members have different amounts of experience with each.

### Krita <a name="krita"></a>
Krita is a 2D art program that we will be using for any concept art and for any possible textures that we need to make.

### Google Documents <a name="google-docs"></a>
We are using google drive to store our GDD and Project Plan so that it is easily accessed by all team members, and so we can update them at the same time as each other.

## Methodology <a name="method"></a>
### Planned Meetings <a name="planned-meetings"></a>
The following meetings are going to be held weekly:

**Tuesdays**: Supervision meeting, where we will discuss with the teachers how the project is going.

**Wednesdays**: Meeting with the music designers where we check our progression as a whole with them.

**Friday**: Casual and relaxed meeting with the game development students where we discuss what issues we’ve encountered and we do a quick demo of what we’ve accomplished over the week. This meeting is meant to be very relaxed and just lets us check in quickly if anyone needs additional help to keep to the plan.

### Sprints <a name="sprints"></a>
We plan on holding two sprints where we combine everything we’ve done so far in pre production. One will be done at the end of Week 2 and one at the end of pre production.

At the first sprint, we should have a game that has a start menu and that can be paused. In the game the character should have a working ice skating controller and there should be ice that they can skate over , there should also be water and objects that show deterioration from having been under the water for too long. Under the water there should be three different types of AIs. One that follows you around, one that leads you to specific areas, and one that has them act like schools of fish. The game should be able to recognize when the player moves in a certain pattern, and the world should react in some way when the player manages to move in these patterns.

At the second sprint, we should have all the features tested together to make sure they all work before we start production.

## Risk analysis <a name="risk-analysis"></a>
The purpose of this risk analysis is to make sure that all team members are aware of what actions we are taking to prevent serious hiccups in our development process, and that if anything does happen, we are all aware of what we need to do to fix the issue.

**Probability**:

*Low* - The risk should not appear more than once during the development process, or the chance that it does appear is negligible.

*Medium* - The risk might be relevant two to five times during the development process, or the chance that it happens at least once is fairly likely.

*High* - The risk is likely to happen multiple times during the development process, or the chance that it happens at least once is very high.

**Consequences**:

*Low* - The risk should not have any major impacts on the project as a whole, only costing a few hours at most.

*Medium* - The risk could be equivalent to losing a few days of progress.

*High* - The risk appearing could result in us having to cut back on important features or it might significantly impact the gameplay experience.

### Identified Risks <a name="identified-risks"></a>

<details>
<summary> #1 Character Controller ends up clunky <a name="character-controller"></a> </summary>

The main thing that could end up causing issues is the character controller. We’re highly concerned with making sure that it comes out nicely, as our goal is to create a game that is relaxing. If the character controller does not come out well, the entire game will feel empty and unfun.

**Probability**: Medium

**Consequences**: High

**Plan of Action**: During pre-production we plan on hopefully being able to create a few different types of controllers. We then plan on testing these controllers as soon as possible. While QA comes later in the project, this is one part that the sooner we test it, the better the end result is going to be. If we find that the controller is still not good enough when we reach QA, we need to make sure that we can tweak every aspect of it easily so that we can more easily respond to any feedback we receive.
</details>

<details>
<summary> #2 Underestimation of how much work the colour mechanic is <a name="color-mechanic"></a> </summary>

There’s a concern that we have misinterpreted how much work removing and adding colours to a lot of objects ends up being.

**Probability**: Low

**Consequences**: High

**Plan of Action**: We’ve taken the time to discuss multiple ways of handling this mechanic. We could possibly handle this through a shader, and if we can then once the shader is done the amount of work to handle it going forward is very minimal. Another way of handling it is through creating different materials or textures for every object that needs to change colour. This might end up being more work, however it should not be that much more work by our estimates. If we are wrong however, the amount of time that would need to be spent on the colour mechanic might end up being too much, and in that case we would need to cut back on how many objects are actually affected by this mechanic.
</details>

<details>
<summary> #3 Git Issues <a name="git-issues"></a> </summary>

There’s a risk of there being merge conflicts when merging things into main.

**Probability**: Low

**Consequences**: Low

**Plan of Action**: By using githubs project board, and making sure any Issues we have are intended to be finished within one day of work, the merges we make should not be very large. This means that any risk of merge conflicts appearing is much lower, it also means that if there are any issues, we can easily go back and rebase commits.
</details>

<details>
<summary> #4 Sickness <a name="sickness"></a> </summary>

Due to the limited amount of time, and having a smaller development team, any sickness that would lead to any member being unable to work could have drastic impacts depending on when it happens. Especially now during covid-19, the risk of any member or any close family member getting sick is increased.

**Probability**: High

**Consequences**: High

**Plan of Action**: The only action we can take to mitigate this happening is to continue to stay safe whenever we can. If we end up in a situation where one of us gets majorly sick, the other members will try to cover the vital parts of the projects. If necessary, we might need to remove some minor parts to make sure that we get a complete game.
</details>

<details>
<summary> #5 Sound Issues <a name="sound"></a> </summary>

None of us have any extensive experience when it comes to implementing music and sounds into a game, and as this is an integral part of the game experience, we might encounter some issues here. Viktor has some experience when it comes to music, however the rest of the game development students have no experience with it.The music / sound designers have no experience working with Wwise or with Unity, so some issues are likely to appear.

**Probability**: High

**Consequences**: Medium

**Plan of Action**: The only preventive action we can take is that we try our best to familiarize ourselves with working with Wwise and with how Unity handles sounds. If any issues do come up, the unfortunate situation is that we will just have to sit down as a group until we figure out what’s causing the issues.
</details>

<details>
<summary> #6 Performance <a name="performance"></a> </summary>

Having larger schools of fish could lead to performance taking a hit.

**Probability**: Medium

**Consequences**: Medium

**Plan of Action**: We will be using known optimizations for handling large schools of fish, such as Boids, which should severely lower the amount of performance needed to handle large amounts of small AIs. If we still end up with performance issues, we will need to consider creating something like a quadtree, where we can turn off AIs that are further away from the player. A change like this would take some time to implement, and would therefore rather be something we avoid. If the quadtree also does not work, we would need to look at a compute shader, which we have no experience with.
</details>

<details>
<summary> #7 Underestimation of shader work <a name="shaders"></a> </summary>

There is a risk that one of the many shaders we want to use doesn’t end up working the way we want it to, or that it ends up being much more work than we expected it to be. Our experience working with shaders is fairly limited, though Danny and Isak have some.

**Probability**: Medium

**Consequences**: High

**Plan of Action**: Any of the shaders we think is going to take time has been given a generous amount of time to make sure that we can focus on it for an extended period. If it still ends up being too much work, we will have to look at possibly scaling back some visual elements.
</details>

<details>
<summary> &lt;id&gt; &lt;Namn på risk&gt; <a name="placeholder1"></a> </summary>

\<text med beskrivning>

**Probability**: Low/Medium/High

**Consequences**: Low/Medium/High

**Plan of Action**: <text som beskriver hur risken kan minskas samt vad man kan göra om risken inträffar. >
</details>

<details>
<summary> &lt;id&gt; &lt;Namn på risk&gt; <a name="placeholder2"></a> </summary>

\<text med beskrivning>

**Probability**: Low/Medium/High

**Consequences**: Low/Medium/High

**Plan of Action**: <text som beskriver hur risken kan minskas samt vad man kan göra om risken inträffar.>
</details>

## Risk diagram <a name="risk-diagram"></a>

| Consequences |     |        |      |             |
|--------------|-----|--------|------|-------------|
| High         | #2  | #1 #7  | #4   |             |
| Medium       |     | #6     | #5   |             |
| Low          | #3  |        |      |             |
|              | Low | Medium | High | **Probability** |
