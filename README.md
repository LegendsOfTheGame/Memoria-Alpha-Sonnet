# Memoria Alpha

**FFXIV Quest Tracking & Journal System**

A comprehensive Dalamud plugin for Final Fantasy XIV that organizes and tracks Main Scenario Quests, dungeons, trials, side content, and player progression across all expansions.

---

## 🚧 Development Status

**Current Version:** `14.2.0.0`  
**Status:** Early Development (Foundation Complete)

### ✅ Implemented
- Quest data loading system (210 ARR MSQ quests)
- Table of Contents (TOC) structure for 68 quest categories
- Player progress detection (tracks completed MSQ milestones)
- Repository pattern for quest data management

### 🔨 In Progress
- UI window and quest browser
- Command handlers (`/memoria`)
- Quest completion tracking

### 📋 Planned
- Interactive quest drawers (MSQ, Features, Beast Tribes, etc.)
- Expansion coverage: HW → StB → ShB → EW → DT
- Quest notes and personal annotations
- Progress statistics and achievements

---

## 📦 Installation

> **⚠️ Not Yet Available:** This plugin is in early development and not yet on the Dalamud Plugin Repository.

### For Developers
1. Clone this repository
2. Open in Visual Studio 2022
3. Build (Ctrl+Shift+B)
4. Add `bin\x64\Debug\` to Dalamud Dev Plugin Locations
5. Enable "Memoria Alpha" in `/xlplugins`

---

## 🎯 Project Goals

**"Learning C# by building something useful"**

Memoria Alpha is both:
- A practical tool for FFXIV quest tracking
- A learning project to develop intermediate-advanced C# skills

### Core Principles
- **Readable code** over clever tricks
- **Incremental progress** with working checkpoints
- **Modern C# patterns** (.NET 8, nullable types, LINQ)
- **User-first design** (simple, intuitive, performant)

---

## 📖 Versioning

Memoria Alpha uses **AA.B.E.D** format:
- **AA** = Dalamud API version (14 = API 14)
- **B** = Expansion band (2 = ARR, 3 = HW, etc.)
- **E** = Expansion patch (0 = x.0, 5 = x.5)
- **D** = Drawer completion milestone (0-9)

**Example:** `14.2.0.1` = API 14, ARR 2.0, MSQ drawer complete

See [VERSIONING.md](VERSIONING.md) for full specification.

---

## 🛠️ Tech Stack

- **Language:** C# .NET 8.0
- **Framework:** Dalamud Plugin API 14
- **UI:** ImGui (via Dalamud)
- **Data:** JSON-based quest repository
- **Tools:** Visual Studio 2022, VS Code, GitHub Desktop

---

## 📜 License

[AGPL-3.0-or-later](LICENSE)

---

## 🙏 Acknowledgments

Built with [Dalamud](https://github.com/goatcorp/Dalamud) - the FFXIV plugin framework  
Quest data sourced from the FFXIV community

---

**Status:** Pre-Alpha | **Target Release:** TBD | **Made with 💙 by LegendsOfTheGame**
