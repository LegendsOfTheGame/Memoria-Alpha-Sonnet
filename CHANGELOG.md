# Changelog

All notable changes to Memoria Alpha will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to **AA.B.E.D** versioning (see [VERSIONING.md](VERSIONING.md)).

---

## [Unreleased]

### Added
- UI window for quest browsing (in progress)
- Command handlers for `/memoria` (in progress)

---

## [14.2.0.0] - 2026-02-03

### Added
- Initial plugin structure and foundation
- `QuestRepository` for loading quest data from JSON files
- `Quest` and `TocEntry` models with nullable type safety
- Table of Contents (TOC) system for organizing 68 quest categories
- Player progress detection using Dalamud ClientState
- Data architecture: ARR 2.0 MSQ (210 quests loaded)
- `ServiceContainer` for dependency management
- Plugin manifest and Dalamud API 14 compatibility

### Technical
- .NET 8.0 with Dalamud.NET.Sdk 14.0.1
- Project structure: Models/, Services/, Data/
- Build pipeline configured for Visual Studio 2022
- Dev plugin hot-reload support

### Known Issues
- No UI window yet (backend only)
- No command handlers implemented
- Quest data limited to ARR 2.0 MSQ only

---

[Unreleased]: https://github.com/LegendsOfTheGame/Memoria-Alpha-Sonnet/compare/v14.2.0.0...HEAD
[14.2.0.0]: https://github.com/LegendsOfTheGame/Memoria-Alpha-Sonnet/releases/tag/v14.2.0.0
