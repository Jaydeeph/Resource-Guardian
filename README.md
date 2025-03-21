# Resource Guardian 🛡️

A Windows utility to manage processes and services safely. Stop non-critical items gracefully, restore them with one click, and protect critical system components using exclusion lists. Built with C# and .NET.

```
Please note, I'm trying to learn C# again after 10 years, so code may be rusty.
```

---

## Features ✨

- **Intelligent Process/Service Management**  
  - Graceful termination with automatic force-kill fallback
  - Predefined safe list (`predefined_safe_list.json`) for recommended stoppable items
  - Protected system processes/services (e.g., `csrss`, `EventLog`)

- **State Persistence**  
  - Save/load selections via `termination_selections.json`
  - Restore previously stopped items with single-click recovery

- **Admin Mode**  
  - UAC elevation for privileged operations
  - Handles "Access Denied" errors for protected resources

- **Diagnostic Tools**  
  - Automatic logging of protected items (`protected_items.log`)

---

## Installation ⚙️

### Requirements
- Windows 10/11
- [.NET 6 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Administrator privileges (recommended)

### Build from Source
```bash
git clone https://github.com/Jaydeeph/Resource-Guardian.git
cd resource-guardian
dotnet build
```

---

## Usage 🖥️

1. **Launch Application**  
   Right-click executable → *Run as Administrator* for full access.

2. **Main Interface**  
   - **Processes Tab**: View executable paths and select non-critical processes  
   - **Services Tab**: Manage Windows services with display names  
   - **Status Bar**: Operation feedback and error messages  

3. **Core Actions**  
   | Button | Action |
   |---|---|
   | 🛑 Stop Selected | Gracefully terminate checked items |
   | 🔄 Restore | Relaunch previously stopped items |
   | ⚙️ Settings | Configure persistent selections |

---

## Configuration ⚙️

### Key Files
| File | Purpose |
|------|---------|
| `predefined_safe_list.json` | recommended safe-to-stop items |
| `termination_selections.json` | User's saved selections |
| `app.manifest` | Admin privilege configuration |

### Custom Safe List Example
```json
{
  "Processes": ["notepad", "chrome"],
  "Services": ["WSearch", "Fax"]
}
```

---

## Troubleshooting ⚠️

**Issue**: "Access Denied" errors  
**Solution**:  
1. Always run as Administrator  
2. Check `protected_items.log` for skipped items  
3. Update `predefined_safe_list.json` if false positives occur  

**Issue**: Selections not persisting  
**Solution**:  
1. Verify `termination_selections.json` exists in executable directory  
2. Ensure selections use process/service **names** not display text  

---

## Contributing 🤝

1. Fork the repository  
2. Create feature branch (`git checkout -b feature/improvement`)  
3. Commit changes (`git commit -m 'Add feature'`)  
4. Push to branch (`git push origin feature/improvement`)  
5. Open Pull Request  

---

## License 📄
MIT License - See [LICENSE](LICENSE) for details

---

## To Do:
- [ ] Add screenshots
- [ ] Improve GUI
- [ ] Add AI suggestions for application/service termination
- [ ] Add diagnostic tools
- [ ] Add run on startup