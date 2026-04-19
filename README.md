# Themvlab_spatialtrainer_MRdemo
Repo for "The mv lab spatial trainer MR demo"

## The mv lab spatial game prototype (version 1, summer 2024) README

# Project Specs

Platform: Standalone MR (Meta Quest 3\)  
Production to: Vertical slice prototype stage  
Originally developed in Summer 2024 on: Unity LTS 2022.3.38f1

Unity project download link here: [*the mv lab spatial game.zip*](https://drive.google.com/file/d/1bg_gGqjhk5wTbeBPEP4b0tQFrKxQt_Y8/view?usp=sharing)

Game build download link here: [*the mv lab spatial game v1.06.apk*](https://drive.google.com/file/d/1kCZ4ZpsyZ83q67txsmX3oAeto4vPOfTl/view?usp=sharing)

# Production Documentation

### Complete

[High Level Vision Canvas](https://docs.google.com/spreadsheets/d/1OUFD3dFQAFdpUNf7-KfUc0jByYsWP_2cpxyP3DAPkeQ/edit?usp=sharing)

[Research](https://docs.google.com/document/d/1Z9hLdESogGG9nkDS9usbGRKKBeSVu2aZVFyy-cBvB8Q/edit?usp=sharing)

[Tone Target for VR version](https://docs.google.com/presentation/d/1JLjyHCFiCe_j9EiqJCjV9jwhKX8h2eO4IyvFhpUAfDs/edit?usp=sharing)

[Feature List w/ Schedule](https://docs.google.com/spreadsheets/d/1TS2v5ApDmoe-Kuq5IXJUJgd191MJO3_3kWjeyqbUWTs/edit?usp=sharing)

[Production Schedule](https://docs.google.com/document/d/1DIRYu5bFW8LlSkSEjDpbdGjdyPoa8PNSMJhjq0NtrFE/edit?usp=sharing)

[Game Loop](https://www.figma.com/board/h5O1SROUGN26bYtuAFapdq/the-mv-lab-spatial-game---game-loop?node-id=0-1&t=lNxlQGPRg8YbmNJf-1)

[Asset List](https://docs.google.com/spreadsheets/d/1NKabORvPpJryxJLFjoXtLYShJz4-crFX8u00UTgFrCU/edit?usp=sharing)

[Acknowledgement & Attribution](https://docs.google.com/document/d/1DcJl0QLqfec7CZuRpw2xXoKVc_xbWeLuP-7ii7FwQ30/edit?usp=sharing)

[Voiceover Script](https://docs.google.com/document/d/1WPSfc5VldXm06-SHS9Xj9fiAPiy4kTif12yOu12-GMk/edit?usp=sharing)

\#README

### Incomplete

System List

System Technical Design Documents (TDDs)

[UI Design](https://docs.google.com/document/d/1SlLhugtaX38vAHN37RyGdnAqET8yGyFsYcHTRNB5xu4/edit?usp=sharing)

QA Test Requirements

Playtest Feedback Form

# Original Scope

The original project scope included the implementation of the following features, as described in the [feature list](https://docs.google.com/spreadsheets/d/1TS2v5ApDmoe-Kuq5IXJUJgd191MJO3_3kWjeyqbUWTs/edit?usp=sharing) \- “\# D & \# P” represents number of estimates Design and Programming hours to complete:

* Standalone Virtual Reality player  
* Touch controller input  
* Scale Trainer  
  * Scale visualization: live representation of scales with a full set of beats  
  * Trainer Mode: A "playable" set of 4 scales with multiple difficulty levels per scale \- 10 D & 30 P  
  * Custom Mode (stretch goal) \- 10 D & 20 P  
  * Endless Mode (stretch goal) \- 5 D & 10 P  
  * Ghost Mode (stretch goal) \- 10 D & 30 P  
  * Difficulty subsystem with the following difficulty components (stretch goal): \- 10 D & 40 P  
    * Difficulty components:  
      * Pathways (central, peripheral, combo)  
      * Time/rhythm (tutorial \= no rhythm)  
      * Complexity of scale  
      * Repeatability (example: 3x, no mistakes)  
      * Dominant hand versus nondominant  
      * Platonic solid overlay  
  * Pathway line tracing animation \- 2 D & 15 P  
  * Tutorial \- 5 D & 15 P  
* Platonic solid projection around the player \- 2 D & 5 P  
* Kinesphere calibration \- 5 D & 15 P  
* Traceform visualization (stretch goal) \- 5 D & 20 P  
* Movement traceform capture & playback (stretch goal) \- 2 D & 20 P  
* A complete UIUX with a score/feedback subsystem \- 10 D & 20 P  
* Settings menu \- 5 D & 15 P  
* Sonic feedback \- 2 D & 5 P  
* Other audio  
* Haptic feedback for Touch controllers  
* Voiceover \- 2 D & 5 P  
* Particle FX feedback for scales \- 2 D & 5 P  
* Save/Load training profile \- 2 D & 5 P

# Final Scope

The final project scope included the following features:

* Standalone Mixed Reality player  
* Hand tracking input  
* Scale Trainer  
  * Scale visualization: live representation of a scale with a full set of beats  
  * Trainer Mode: A "playable" scale  
    * Current functionality allows many more scales to be quickly implemented  
* Circulating platonic solid projection around the player  
* A basic UIUX with a main menu  
* Sonic feedback  
* Voiceover (all audio recorded; only 1 out of 19 files implemented)  
* VFX indicator to highlight next spatial pull in scale

# Instructions for Use

1. Download the MR project build APK: [the mv lab spatial game v1.06.apk](https://drive.google.com/file/d/1kCZ4ZpsyZ83q67txsmX3oAeto4vPOfTl/view?usp=sharing)  
2. Upload the APK to a Quest 3 headset  
   1. [*Instructions for sideloading*](https://zybervr.com/blogs/news/step-by-step-guide-on-how-to-install-apk-files-on-meta-quest?srsltid=AfmBOop8YTSrkAI7ppqwGTnoSm0nMTj8brMxV5NBDD-fzX_Emr6s712y) (if new to this process, may take a while)  
3. Play app  
4. Start game and proceed through dimensional scale sequence on loop

# INFO 510 Research Practicum Issue Highlights

Challenges of Solo Game Development & Production

* One person must balance all game production disciplines:  
  * Project Management  
  * Design  
  * Programming  
  * Art  
* While there are many helpful resources online, a niche project like the mv lab spatial game has many unique systems that require more independent technical problem-solving than more traditional XR experiences, which will have a bevy of direct tutorials online for the exact systems needed  
* Solo production schedules are more prone to roadblocks, even with strategic schedule planning. Without multiple people to address project roadblocks, the burden of the development challenges multiplies.

Rapidly Changing Nature of Game Technology

* Through VR research development project opportunities with Dr. Jenny Oyallon-Koloski on similar spatial movement app projects from 2019 to now, the evolving tech landscape has posed a hurdle in maintaining game programming knowledge. Even within the same engine (Unity), the tools for developing XR have changed rapidly. I have heard that in the games industry, development tools will change every 6 months. This provides an extra burden for programmers to stay up-to-date on their game engine knowledge set. This contributed to a frustration with the programming process on this project; I could not port as many of my previously implemented tools from the 2019 *mv lab’s Virtual Reality Tool* to the 2024 *mv lab spatial game* as I would have liked.

The Key Collaboration with the Subject Matter Expert (SME) or Domain Expert (DE)

* The relationship between the SME/DE is the cornerstone of the production of an impactful serious games tool. The developer/producer needs to maintain a consistent collaboration with the SME/DE over the design and implementation of the project to keep it on track toward its domain-based objective. The SME/DE also plays a key role in providing expectations and feedback based on testing sessions internally and with public participants.

# Brief Reflection on Personal & Research Matters

This research practicum was clarifying for me in terms of personal and research matters in several ways. First, it reaffirmed the complex challenge of game development work. Pursuing solo game development projects has not become sustainable for me because of the issues highlighted above. Now, I prefer to work in teams within a scope supported by others. This practicum also clarified what I will and will not be able to do for research. In the future, I will work toward more poster- and paper-worthy research material. The project could have materialized into those materials given another semester. I believe that impact studies on the games of mine and others are the biggest gold mine to tap into for future research. Additionally, I believe I will be more effective at developing research output addressing the unique production issues of educational games.

My Informatics PhD specialization is Design, Tech, and Society. Ultimately, these three elements should be my focus, and coding/programming is a fraction of the tech domain I need to stay up to speed with. Additionally, through my RA at the student-run campus game studio, I am uncovering that I want to add production into my focus on top of design, tech, and society. Applications need to be produced to carry through on the impact potential of research in educational and other serious digital games. I will continue directing my focus there so that the campus and I can better understand the impact of games by studying them and making them.

# Future Steps & a Realistic Production Plan to Completion

*Would a team of multiple people with specific software/technical skills be able to work together to develop this, and if so, how could that be organized?*

Yes. Here are the steps for completion of the *mv lab spatial game*:

1. Refactor code documentation for readability by the next Unity programmer.  
2. The project features receive a reassessment by the SME/DE to align with her learning objective priorities.  
3. Acquire the appropriate amount of grant funding.  
   1. According to my rough assessment, the original project scope would require a total budget of $4,816-7,840. That would be $799-1,513 for the designer ($17/hr), $3,150-4,950 for the programmer ($18/hr), and $867-1,377 for the project manager ($17/hr). The high end of the range includes all stretch goal features.  
4. Hire a development team with the essential workers: 1 project manager, 1 designer, and 1 Unity programmer. I will run the project as the producer, and Dr. Jenny Oyallon-Koloski will support the project as the SME/DE.  
5. Re-estimate the project scope to a reasonable timeline within the budget based on a team assessment.  
   1. Based on my current assessment, the original project scope would be completed in 17-27 weeks. This would be 47-89 design hours, 175-275 programming hours, and 51-81 project management hours at roughly 3 design, 10 programming, and 3 project management hours of work per week. Still, individual development team members, especially the programmer, must review and edit this timeline.  
6. The designer and programmer spend time in the pre-production phase designing systems more effectively and creating Technical Design Docs (TDDs) for each core system.  
7. The project manager sees the team through to project completion, including the 2 QA tests and public playtest(s) in the scope of the original schedule.  
8. The project is launched within the timeline with several iteration cycles to assure quality and alignment with the domain goals of the project.

# Acknowledgement & Attribution

This project has been developed by Informatics PhD student Robbie Sieczkowski (rms6@illinois.edu) and supervised by Dr. Jenny Oyallon-Koloski.

This project is based on the work of the movement visualization (mv) lab, which is co-directed by Dr. Jenny Oyallon-Koloski and Dr. Michael J. Junokas.

All voiceovers were recorded by Dr. Jenny Oyallon-Koloski.

Asset attribution [here](https://docs.google.com/document/d/1DcJl0QLqfec7CZuRpw2xXoKVc_xbWeLuP-7ii7FwQ30/edit?usp=sharing).

Built with the Unity game engine by Unity Technologies.  
