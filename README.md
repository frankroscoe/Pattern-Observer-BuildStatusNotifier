# Observer Pattern — BuildStatusNotifier

## Overview
This project demonstrates the **Observer** design pattern using a build‑status notification scenario.  
The pattern defines a one‑to‑many dependency between objects so that when the subject changes state, all registered observers are automatically notified.

This example is designed as a clear, educational reference for students and recruiters.

---

## UML Diagram
The following UML class diagram illustrates the structure of the Observer pattern in this project:

![UML Diagram](./docs/Pattern-Observer-BuildStatusNotifier.png)

---

## Participants

### **IBuildSubject (interface)**
Defines the contract for managing observers:
- `Attach(observer)`
- `Detach(observer)`
- `Notify()`

### **IBuildObserver (interface)**
Defines the contract for receiving updates:
- `Update(status)`

### **BuildStatusNotifier (concrete subject)**
Maintains a list of observers and notifies them when the build status changes.

### **Concrete Observers**
Each observer implements `IBuildObserver` and reacts to status updates:
- `ConsoleLoggerObserver`
- `FileLoggerObserver`
- `EmailNotificationObserver`
- `ChecklistVerificationObserver`

---

## Intent of This Example
This example models a realistic workflow where multiple components need to react to build‑status changes.  
It demonstrates:
- Loose coupling between subject and observers  
- Dynamic registration and removal of observers  
- A clean, interface‑driven design suitable for teaching and interviews  

---
## Current Implementation Status 
The following components are complete: 
- Interfaces (`IBuildSubject`, `IBuildObserver`) 
- Concrete subject (`BuildStatusNotifier`) 
- First observer (`ConsoleLoggerObserver`) 
- Working demo wired together in `Program.cs` 
 
You can run the project now to see the Observer pattern in action.

---
## Coming Next
Additional observers and documentation will be added: 

### **C# Implementation**
- File logger observer
- Email notification observer (simulated)
- Checklist verification observer (simulated)
- Example usage patterns 

### **Example Output** 
Sample console output showing observer reactions.

### **Teaching Notes**
Guidance for students on: 
- When to use Observer 
- Common pitfalls 
- How this pattern appears in real systems 

---