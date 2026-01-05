```markdown
# LibreWorlds.WorldRuntime

## Overview

**LibreWorlds.WorldRuntime** is the authoritative execution layer of the LibreWorlds client pipeline.

It consumes world commands produced upstream (SDK → Adapter → Queue) and applies them deterministically to a concrete world engine implementation. This project is responsible for **when** and **how** world state changes occur, but not for producing those changes.

> If something changes in the world, it happens here.

## Responsibilities

The WorldRuntime is responsible for:

- Executing queued world commands in a controlled, ordered manner
- Acting as the single authority that mutates world state
- Bridging abstract commands to a concrete `IWorldEngine`
- Enforcing a strict separation between data production and execution
- Providing a stable runtime surface for engines (Godot, native, headless)

## What This Is

- A world execution runtime
- A deterministic command processor
- A boundary between logic and rendering
- An engine-agnostic world mutation layer
- The final step before objects appear, move, or disappear

## What This Is NOT

- Not a renderer
- Not a networking layer
- Not a protocol implementation
- Not a UI
- Not a queue
- Not a simulator or mock

> The runtime does not invent commands.  
> It only executes commands that already exist.

## High-Level Architecture


LibreWorlds SDK
        ↓
WorldAdapter
        ↓
WorldCommandQueue
        ↓
WorldRuntime
        ↓
IWorldEngine (Godot / Native / Headless)


Data flows strictly downward.  
Authority flows strictly downward.

## Core Concepts

### WorldRuntime
The central coordinator that owns:

- A `WorldCommandProcessor`
- A reference to an `IWorldEngine`
- The execution loop that drains and applies commands

It does not care where commands come from — only that they are valid.

### WorldCommandProcessor
Responsible for:

- Pulling commands from the queue
- Executing them in order
- Applying them to the engine via a stable interface

This ensures:

- Thread safety
- Ordering guarantees
- Deterministic world updates

### IWorldCommand
Represents a single, atomic world mutation.  
Examples:

- Add object
- Update object transform
- Remove object

Commands carry data only and expose a single execution contract.

### IWorldEngine
An abstraction over any concrete engine implementation.  
Examples:

- Godot GDExtension engine
- Native C++ engine
- Test or headless engine

The runtime does not know how the engine renders — only what to apply.

## Design Principles

- **Single Authority** — Only the runtime mutates world state
- **No Hidden Side Effects** — Commands execute explicitly
- **Engine Agnostic** — Runtime does not depend on rendering tech
- **Deterministic Execution** — Same commands → same world state
- **Clear Boundaries** — Each layer has one job

## Intended Use

This project is used to:

- Execute real world updates produced by LibreWorlds SDKs
- Drive engines without coupling them to networking or protocol code
- Validate integration correctness under real load
- Serve as the execution backbone for future clients

## Current Status

- World command execution pipeline implemented
- Clean separation from queue and adapter layers
- Builds successfully against LibreWorlds.WorldQueue
- Ready for engine integration

## Philosophy

> The runtime does not guess.  
> The runtime does not simulate.  
> The runtime executes what actually happened.
```
