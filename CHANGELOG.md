# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- Initial Maybe type and tests
- ValueOr Func, invokes if the maybe is None
- TryOrNone, helper on Maybe, takes a func to wrap in a maybe, if anything throws returns None.

### Changed

- GetComponentOrNone has no constraints, allows for use of interfaces