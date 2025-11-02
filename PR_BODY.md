# Docs: XML IntelliSense + pack-only doc generation

This PR improves developer experience and packaging:

## Summary
- Translate and complete XML documentation for all public APIs in `RandomUtility`, `RandomUtility.Nullable`, and `RandomUtility.Tuple`.
- Enable XML documentation generation only during `dotnet pack` to avoid stray XML outputs in dev builds, while ensuring IntelliSense docs ship in the NuGet package.
- Keep dev builds single-target for faster inner-loop; pack remains multi-target.

## Changes
- docs(random): translate and complete XML docs for RandomUtility, Nullable, and Tuple
- build(pack): condition pack-only settings at PropertyGroup level
  - Multi-target only during pack
  - Generate XML docs only when packing
  - Include .xml in nupkg output

## CI/Release context (existing on main)
- Code coverage collection via coverlet and upload to Codecov (matrix by TFM)
- Test reporting via `dorny/test-reporter` using TRX

## Notes
- No functional code changes; documentation-only plus build configuration for packaging.
- Validated with `dotnet build` and `dotnet pack`; nupkg contains XML docs next to assemblies.
