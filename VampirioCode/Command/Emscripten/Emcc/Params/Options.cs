using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.Emscripten.Emcc.Params
{
    public class Options
    {
        //
        // INFO: https://github.com/emscripten-core/emscripten/blob/main/src/settings.js
        //

        /// <summary>
        /// Whether we should add runtime assertions. This affects both JS and how
        /// system libraries are built.
        /// ASSERTIONS == 2 gives even more runtime checks, that may be very slow. That
        /// includes internal dlmalloc assertions, for example.
        /// [link]
        /// </summary>
        public int? Assertions = null; //Default: 1


        /// <summary>
        /// Chooses what kind of stack smash checks to emit to generated code:
        /// Building with ASSERTIONS=1 causes STACK_OVERFLOW_CHECK default to 1.
        /// Since ASSERTIONS=1 is the default at -O0, which itself is the default
        /// optimization level this means that this setting also effectively
        /// defaults 1, absent any other settings:
        ///
        /// - 0: Stack overflows are not checked.
        /// - 1: Adds a security cookie at the top of the stack, which is checked at end
        ///   of each tick and at exit (practically zero performance overhead)
        /// - 2: Same as above, but also runs a binaryen pass which adds a check to all
        ///   stack pointer assignments. Has a small performance cost.
        ///
        /// [link]
        /// </summary>
        public int? StackOverflowCheck = null; //Default: 0

        /// <summary>
        /// When STACK_OVERFLOW_CHECK is enabled we also check writes to address zero.
        /// This can help detect NULL pointer usage.  If you want to skip this extra
        /// check (for example, if you want reads from the address zero to always return
        /// zero) you can disabled this here.  This setting has no effect when
        /// STACK_OVERFLOW_CHECK is disabled.
        /// </summary>
        public bool? CheckNullWrites = null; //Default: true

        /// <summary>
        /// When set to 1, will generate more verbose output during compilation.
        /// [general]
        /// </summary>
        public bool? Verbose = null; //Default: true

        /// <summary>
        /// Whether we will run the main() function. Disable if you embed the generated
        /// code in your own, and will call main() yourself at the right time (which you
        /// can do with Module.callMain(), with an optional parameter of commandline args).
        /// [link]
        /// </summary>
        public bool? InvokeRun = null; //Default: true

        /// <summary>
        /// If 0, the runtime is not quit when main() completes (allowing code to
        /// run afterwards, for example from the browser main event loop). atexit()s
        /// are also not executed, and we can avoid including code for runtime shutdown,
        /// like flushing the stdio streams.
        /// Set this to 1 if you do want atexit()s or stdio streams to be flushed
        /// on exit.
        /// This setting is controlled automatically in STANDALONE_WASM mode:
        ///
        /// - For a command (has a main function) this is always 1
        /// - For a reactor (no a main function) this is always 0
        ///
        /// [link]
        /// </summary>
        public bool? ExitRuntime = null; // Default: false

        /// <summary>
        /// The total stack size. There is no way to enlarge the stack, so this
        /// value must be large enough for the program's requirements. If
        /// assertions are on, we will assert on not exceeding this, otherwise,
        /// it will fail silently.
        /// [link]
        /// </summary>
        public int? StackSize = null; // Default: 64*1024

        /// <summary>
        /// What malloc()/free() to use, out of:
        /// - dlmalloc
        /// - emmalloc
        /// - emmalloc-debug
        /// - emmalloc-memvalidate
        /// - emmalloc-verbose
        /// - emmalloc-memvalidate-verbose
        /// - mimalloc
        /// - none
        ///
        /// dlmalloc is necessary for split memory and other special modes, and will be
        /// used automatically in those cases.
        /// In general, if you don't need one of those special modes, and if you don't
        /// allocate very many small objects, you should use emmalloc since it's
        /// smaller. Otherwise, if you do allocate many small objects, dlmalloc
        /// is usually worth the extra size. dlmalloc is also a good choice if you want
        /// the extra security checks it does (such as noticing metadata corruption in
        /// its internal data structures, which emmalloc does not do).
        /// [link]
        /// </summary>
        public string Malloc = null; // Default: "dlmalloc"

        /// <summary>
        /// If 1, then when malloc would fail we abort(). This is nonstandard behavior,
        /// but makes sense for the web since we have a fixed amount of memory that
        /// must all be allocated up front, and so (a) failing mallocs are much more
        /// likely than on other platforms, and (b) people need a way to find out
        /// how big that initial allocation (INITIAL_MEMORY) must be.
        /// If you set this to 0, then you get the standard malloc behavior of
        /// returning NULL (0) when it fails.
        ///
        /// Setting ALLOW_MEMORY_GROWTH turns this off, as in that mode we default to
        /// the behavior of trying to grow and returning 0 from malloc on failure, like
        /// a standard system would. However, you can still set this flag to override
        /// that.  This is a mostly-backwards-compatible change. Previously this option
        /// was ignored when growth was on. The current behavior is that growth turns it
        /// off by default, so for users that never specified the flag nothing changes.
        /// But if you do specify it, it will have an effect now, which it did not
        /// previously. If you don't want that, just stop passing it in at link time.
        ///
        /// Note that this setting does not affect the behavior of operator new in C++.
        /// This function will always abort on allocation failure if exceptions are disabled.
        /// If you want new to return 0 on failure, use it with std::nothrow.
        ///
        /// [link]
        /// </summary>
        public bool? AbortingMalloc = null; // Default: true

        /// <summary>
        /// The initial amount of memory to use. Using more memory than this will
        /// cause us to expand the heap, which can be costly with typed arrays:
        /// we need to copy the old heap into a new one in that case.
        /// If ALLOW_MEMORY_GROWTH is set, this initial amount of memory can increase
        /// later; if not, then it is the final and total amount of memory.
        ///
        /// (This option was formerly called TOTAL_MEMORY.)
        /// [link]
        /// </summary>
        public int? InitialMemory = null; // Default: 16777216

        /// <summary>
        /// Set the maximum size of memory in the wasm module (in bytes). This is only
        /// relevant when ALLOW_MEMORY_GROWTH is set, as without growth, the size of
        /// INITIAL_MEMORY is the final size of memory anyhow.
        ///
        /// Note that the default value here is 2GB, which means that by default if you
        /// enable memory growth then we can grow up to 2GB but no higher. 2GB is a
        /// natural limit for several reasons:
        ///
        /// To use more than 2GB, set this to something higher, like 4GB.
        ///
        /// (This option was formerly called WASM_MEM_MAX and BINARYEN_MEM_MAX.)
        /// [link]
        /// </summary>
        public long? MaximumMemory = null; // Default: 2147483648

        /// <summary>
        /// If false, we abort with an error if we try to allocate more memory than
        /// we can (INITIAL_MEMORY). If true, we will grow the memory arrays at
        /// runtime, seamlessly and dynamically.
        /// See https://code.google.com/p/v8/issues/detail?id=3907 regarding
        /// memory growth performance in chrome.
        /// Note that growing memory means we replace the JS typed array views, as
        /// once created they cannot be resized. (In wasm we can grow the Memory, but
        /// still need to create new views for JS.)
        /// Setting this option on will disable ABORTING_MALLOC, in other words,
        /// ALLOW_MEMORY_GROWTH enables fully standard behavior, of both malloc
        /// returning 0 when it fails, and also of being able to allocate more
        /// memory from the system as necessary.
        /// [link]
        /// </summary>
        public bool? AllowMemoryGrowth = null; // Default: null

        /// <summary>
        /// If ALLOW_MEMORY_GROWTH is true, this variable specifies the geometric
        /// overgrowth rate of the heap at resize. Specify MEMORY_GROWTH_GEOMETRIC_STEP=0
        /// to disable overgrowing the heap at all, or e.g.
        /// MEMORY_GROWTH_GEOMETRIC_STEP=1.0 to double the heap (+100%) at every grow step.
        /// The larger this value is, the more memory the WebAssembly heap overreserves
        /// to reduce performance hiccups coming from memory resize, and the smaller
        /// this value is, the more memory is conserved, at the performance of more
        /// stuttering when the heap grows. (profiled to be on the order of ~20 msecs)
        /// [link]
        /// </summary>
        public double? MemoryGrowthGeometricStep = null; // Default: null

        /// <summary>
        /// Specifies a cap for the maximum geometric overgrowth size, in bytes. Use
        /// this value to constrain the geometric grow to not exceed a specific rate.
        /// Pass MEMORY_GROWTH_GEOMETRIC_CAP=0 to disable the cap and allow unbounded
        /// size increases.
        /// [link]
        /// </summary>
        public int? MemoryGrowthGeometricCap = null; // Default: null

        /// <summary>
        /// If ALLOW_MEMORY_GROWTH is true and MEMORY_GROWTH_LINEAR_STEP == -1, then
        /// geometric memory overgrowth is utilized (above variable). Set
        /// MEMORY_GROWTH_LINEAR_STEP to a multiple of WASM page size (64KB), eg. 16MB to
        /// replace geometric overgrowth rate with a constant growth step size. When
        /// MEMORY_GROWTH_LINEAR_STEP is used, the variables MEMORY_GROWTH_GEOMETRIC_STEP
        /// and MEMORY_GROWTH_GEOMETRIC_CAP are ignored.
        /// [link]
        /// </summary>
        public int? MemoryGrowthLinearStep = null; // Default: null

        /// <summary>
        /// The "architecture" to compile for. 0 means the default wasm32, 1 is
        /// the full end-to-end wasm64 mode, and 2 is wasm64 for clang/lld but lowered to
        /// wasm32 in Binaryen (such that it can run on wasm32 engines, while internally
        /// using i64 pointers).
        /// Assumes WASM_BIGINT.
        /// [compile+link]
        /// [experimental]
        /// </summary>
        public int? Memory64 = null; // Default: null

        /// <summary>
        /// Sets the initial size of the table when MAIN_MODULE or SIDE_MODULE is use
        /// (and not otherwise). Normally Emscripten can determine the size of the table
        /// at link time, but in SPLIT_MODULE mode, wasm-split often needs to grow the
        /// table, so the table size baked into the JS for the instrumented build will be
        /// too small after the module is split. This is a hack to allow users to specify
        /// a large enough table size that can be consistent across both builds. This
        /// setting may be removed at any time and should not be used except in
        /// conjunction with SPLIT_MODULE and dynamic linking.
        /// [link]
        /// </summary>
        public int? InitialTable = null; // Default: null

        /// <summary>
        /// If true, allows more functions to be added to the table at runtime. This is
        /// necessary for dynamic linking, and set automatically in that mode.
        /// [link]
        /// </summary>
        public bool? AllowTableGrowth = null; // Default: null

        /// <summary>
        /// Where global data begins; the start of static memory.
        /// A GLOBAL_BASE of 1024 or above is useful for optimizing load/store offsets, as it
        /// enables the --low-memory-unused pass
        /// [link]
        /// </summary>
        public int? GlobalBase = null; // Default: null

        /// <summary>
        /// Where where table slots (function addresses) are allocated.
        /// This must be at least 1 to reserve the zero slot for the null pointer.
        /// [link]
        /// </summary>
        public int? TableBase = null; // Default: null

        /// <summary>
        /// Whether closure compiling is being run on this output
        /// [link]
        /// </summary>
        public bool? UseClosureCompiler = null; // Default: null

        /// <summary>
        /// Deprecated: Use the standard warnings flags instead. e.g. ``-Wclosure``,
        /// ``-Wno-closure``, ``-Werror=closure``.
        /// options: 'quiet', 'warn', 'error'. If set to 'warn', Closure warnings are
        /// printed out to console. If set to 'error', Closure warnings are treated like
        /// errors, similar to -Werror compiler flag.
        /// [link]
        /// [deprecated]
        /// </summary>
        public string ClosureWarnings = null; // Default: null

        /// <summary>
        /// Ignore closure warnings and errors (like on duplicate definitions)
        /// [link]
        /// </summary>
        public bool? IgnoreClosureCompilerErrors = null; // Default: null

        /// <summary>
        /// If set to 1, each wasm module export is individually declared with a
        /// JavaScript "var" definition. This is the simple and recommended approach.
        /// However, this does increase code size (especially if you have many such
        /// exports), which can be avoided in an unsafe way by setting this to 0. In that
        /// case, no "var" is created for each export, and instead a loop (of small
        /// constant code size, no matter how many exports you have) writes all the
        /// exports received into the global scope. Doing so is dangerous since such
        /// modifications of the global scope can confuse external JS minifier tools, and
        /// also things can break if the scope the code is in is not the global scope
        /// (e.g. if you manually enclose them in a function scope).
        /// [link]
        /// </summary>
        public bool? DeclareAsmModuleExports = null; // Default: null

        /// <summary>
        /// If set to 1, prevents inlining. If 0, we will inline normally in LLVM.
        /// This does not affect the inlining policy in Binaryen.
        /// [compile]
        /// </summary>
        public bool? InliningLimit = null; // Default: null


        /// <summary>
        /// If set to 1, perform acorn pass that converts each HEAP access into a
        /// function call that uses DataView to enforce LE byte order for HEAP buffer;
        /// This makes generated JavaScript run on BE as well as LE machines. (If 0, only
        /// LE systems are supported). Does not affect generated wasm.
        /// </summary>
        public bool? SupportBigEndian = null; // false

        /// <summary>
        /// Check each write to the heap, for example, this will give a clear
        /// error on what would be segfaults in a native build (like dereferencing
        /// 0). See runtime_safe_heap.js for the actual checks performed.
        /// Set to value 1 to test for safe behavior for both Wasm+Wasm2JS builds.
        /// Set to value 2 to test for safe behavior for only Wasm builds. (notably,
        /// Wasm-only builds allow unaligned memory accesses. Note, however, that
        /// on some architectures unaligned accesses can be very slow, so it is still
        /// a good idea to verify your code with the more strict mode 1)
        /// [link]
        /// </summary>
        public int? SafeHeap = null; // 0

        /// <summary>
        /// Log out all SAFE_HEAP operations
        /// </summary>
        public bool? SafeHeapLog = null; // false

        /// <summary>
        /// Allows function pointers to be cast, wraps each call of an incorrect type
        /// with a runtime correction.  This adds overhead and should not be used
        /// normally.  It also forces ALIASING_FUNCTION_POINTERS to 0.  Aside from making
        /// calls not fail, this tries to convert values as best it can.
        /// We use 64 bits (i64) to represent values, as if we wrote the sent value to
        /// memory and loaded the received type from the same memory (using
        /// truncs/extends/ reinterprets). This means that when types do not match the
        /// emulated values may not match (this is true of native too, for that matter -
        /// this is all undefined behavior). This approaches appears good enough to
        /// support Python, which is the main use case motivating this feature.
        /// [link]
        /// </summary>
        public bool? EmulateFunctionPointerCasts = null; // false

        /// <summary>
        /// Print out exceptions in emscriptened code.
        /// [link]
        /// </summary>
        public bool? ExceptionDebug = null; // false

        /// <summary>
        /// If 1, export `demangle` and `stackTrace` JS library functions.
        /// [link]
        /// [deprecated]
        /// </summary>
        public bool? DemangleSupport = null; // false

        /// <summary>
        /// Print out when we enter a library call (library*.js). You can also unset
        /// runtimeDebug at runtime for logging to cease, and can set it when you want
        /// it back. A simple way to set it in C++ is::
        ///
        ///   emscripten_run_script("runtimeDebug = ...;");
        ///
        /// [link]
        /// </summary>
        public bool? LibraryDebug = null; // false

        /// <summary>
        /// Print out all musl syscalls, including translating their numeric index
        /// to the string name, which can be convenient for debugging. (Other system
        /// calls are not numbered and already have clear names; use LIBRARY_DEBUG
        /// to get logging for all of them.)
        /// [link]
        /// </summary>
        public bool? SyscallDebug = null; // false

        /// <summary>
        /// Log out socket/network data transfer.
        /// </summary>
        public bool? SocketDebug = null; // false

        /// <summary>
        /// Log dynamic linker information.
        /// </summary>
        public int? DylinkDebug = null; // 0

        /// <summary>
        /// Register file system callbacks using trackingDelegate in library_fs.js.
        /// </summary>
        public bool? FsDebug = null; // false

        /// <summary>
        /// Select socket backend, either webrtc or websockets.
        /// </summary>
        public bool? SocketWebrtc = null; // false

        /// <summary>
        /// A string containing either a WebSocket URL prefix (ws:// or wss://) or a complete
        /// RFC 6455 URL.
        /// </summary>
        public string WebSocketUrl = null;// "ws://";

        /// <summary>
        /// If 1, the POSIX sockets API uses a native bridge process server to proxy sockets calls
        /// from browser to native world.
        /// </summary>
        public bool? ProxyPosixSockets = null; // false

        /// <summary>
        /// A string containing a comma separated list of WebSocket subprotocols
        /// as would be present in the Sec-WebSocket-Protocol header.
        /// </summary>
        public string WebSocketSubprotocol = null; // "binary";

        /// <summary>
        /// Print out debugging information from our OpenAL implementation.
        /// </summary>
        public bool? OpenALDebug = null; // false

        /// <summary>
        /// If 1, prints out debugging related to calls from ``emscripten_web_socket_*``
        /// functions in ``emscripten/websocket.h``.
        /// </summary>
        public bool? WebSocketDebug = null; // false

        /// <summary>
        /// Adds extra checks for error situations in the GL library.
        /// </summary>
        public bool? GlAssertions = null; // false

        /// <summary>
        /// If enabled, prints out all API calls to WebGL contexts.
        /// </summary>
        public bool? TraceWebglCalls = null; // false

        /// <summary>
        /// Enables more verbose debug printing of WebGL related operations.
        /// </summary>
        public bool? GlDebug = null; // false

        /// <summary>
        /// When enabled, sets preserveDrawingBuffer in the context, to allow tests to
        /// work (but adds overhead).
        /// </summary>
        public bool? GlTesting = null; // false

        /// <summary>
        /// How large GL emulation temp buffers are.
        /// </summary>
        public int? GlMaxTempBufferSize = null; // 2097152

        /// <summary>
        /// Enables some potentially-unsafe optimizations in GL emulation code.
        /// </summary>
        public bool? GlUnsafeOpts = null; // true

        /// <summary>
        /// Forces support for all GLES2 features, not just the WebGL-friendly subset.
        /// </summary>
        public bool? FullEs2 = null; // false

        /// <summary>
        /// If true, glGetString() for GL_VERSION and GL_SHADING_LANGUAGE_VERSION will
        /// return strings OpenGL ES format "Open GL ES ... (WebGL ...)".
        /// </summary>
        public bool? GlEmulateGlesVersionStringFormat = null; // true

        /// <summary>
        /// If true, all GL extensions are advertised in both unprefixed WebGL extension
        /// format, but also in desktop/mobile GLES/GL extension format with ``GL_``
        /// prefix.
        /// </summary>
        public bool? GlExtensionsInPrefixedFormat = null; // true

        /// <summary>
        /// If true, adds support for automatically enabling all GL extensions for
        /// GLES/GL emulation purposes.
        /// </summary>
        public bool? GlSupportAutomaticEnableExtensions = null; // true

        /// <summary>
        /// If true, the function ``emscripten_webgl_enable_extension()`` can be called to
        /// enable any WebGL extension.
        /// </summary>
        public bool? GlSupportSimpleEnableExtensions = null; // true

        /// <summary>
        /// If set to 0, Emscripten GLES2->WebGL translation layer does not track the kind
        /// of GL errors that exist in GLES2 but do not exist in WebGL.
        /// </summary>
        public bool? GlTrackErrors = null; // true

        /// <summary>
        /// If true, GL contexts support the explicitSwapControl context creation flag.
        /// </summary>
        public bool? GlSupportExplicitSwapControl = null; // false

        /// <summary>
        /// If true, calls to glUniform*fv and glUniformMatrix*fv utilize a pool of
        /// preallocated temporary buffers for common small sizes to avoid generating
        /// temporary garbage for WebGL 1.
        /// </summary>
        public bool? GlPoolTempBuffers = null; // true

        /// <summary>
        /// If true, enables support for the EMSCRIPTEN_explicit_uniform_location WebGL
        /// extension.
        /// </summary>
        public bool? GlExplicitUniformLocation = null; // false

        /// <summary>
        /// If true, enables support for the EMSCRIPTEN_uniform_layout_binding WebGL
        /// extension.
        /// </summary>
        public bool? GlExplicitUniformBinding = null; // false

        /// <summary>
        /// Deprecated. Pass -sMAX_WEBGL_VERSION=2 to target WebGL 2.0.
        /// </summary>
        public bool? UseWebGL2 = null; // false

        /// <summary>
        /// Specifies the lowest WebGL version to target.
        /// </summary>
        public int? MinWebGLVersion = null; // 1

        /// <summary>
        /// Specifies the highest WebGL version to target.
        /// </summary>
        public int? MaxWebGLVersion = null; // 1

        /// <summary>
        /// If true, emulates some WebGL 1 features on WebGL 2 contexts.
        /// </summary>
        public bool? WebGL2BackwardsCompatibilityEmulation = null; // false

        /// <summary>
        /// Forces support for all GLES3 features, not just the WebGL2-friendly subset.
        /// </summary>
        public bool? FullEs3 = null; // false

        /// <summary>
        /// Includes code to emulate various desktop GL features.
        /// </summary>
        public bool? LegacyGLEmulation = null; // false

        /// <summary>
        /// If you specified LEGACY_GL_EMULATION = 1 and only use fixed function pipeline
        /// in your code, you can also set this to 1 to signal the GL emulation layer
        /// that it can perform extra optimizations by knowing that the user code does
        /// not use shaders at all.
        /// </summary>
        public bool? GlFfpOnly = null; // false

        /// <summary>
        /// If you want to create the WebGL context up front in JS code, set this to 1.
        /// </summary>
        public bool? GlPreinitializedContext = null; // false

        /// <summary>
        /// Enables support for WebGPU.
        /// </summary>
        public bool? UseWebGPU = null; // false

        /// <summary>
        /// Enables building of stb-image, a tiny public-domain library for decoding images.
        /// </summary>
        public bool? StbImage = null; // false

        /// <summary>
        /// Disable OES_texture_half_float and OES_texture_half_float_linear extensions if broken in Safari.
        /// </summary>
        public bool? GlDisableHalfFloatExtensionIfBroken = null; // false

        /// <summary>
        /// Workaround Safari WebGL issue related to getContext().
        /// </summary>
        public bool? GlWorkaroundSafariGetContextBug = null; // true

        /// <summary>
        /// If 1, link with support to glGetProcAddress() functionality.
        /// </summary>
        public bool? GlEnableGetProcAddress = null; // true

        /// <summary>
        /// Use JavaScript math functions like Math.tan.
        /// </summary>
        public bool? JsMath = null; // false

        /// <summary>
        /// Enable compatibility emulations for old JavaScript engines.
        /// </summary>
        public bool? LegacyVmSupport = null; // false

        /// <summary>
        /// Specify which runtime environments the JS output will be capable of running in.
        /// </summary>
        public string? Environment = null;// "web,webview,worker,node";

        /// <summary>
        /// Enable support for lz4-compressed file packages.
        /// </summary>
        public bool? Lz4 = null; // false

        /// <summary>
        /// Disables generating code to actually catch exceptions.
        /// </summary>
        public int? DisableExceptionCatching = null; // 1

        /// <summary>
        /// Enables catching exceptions but only in the listed functions.
        /// </summary>
        public string[] ExceptionCatchingAllowed = null; // Empty array

        /// <summary>
        /// Tracks whether Emscripten should link in exception throwing support library.
        /// </summary>
        public bool? DisableExceptionThrowing = null; // false

        /// <summary>
        /// Make the exception message printing function, 'getExceptionMessage' available
        /// in the JS library for use.
        /// </summary>
        public bool? ExportExceptionHandlingHelpers = null; // false

        /// <summary>
        /// Enable stack traces for exceptions.
        /// </summary>
        public bool? ExceptionStackTraces = null; // false

        /// <summary>
        /// Emscripten throws an ExitStatus exception to unwind when exit() is called.
        /// Without this setting enabled this can show up as a top level unhandled exception.
        /// </summary>
        public bool? NodeJSCatchExit = null; // true

        /// <summary>
        /// Catch unhandled rejections in node.
        /// </summary>
        public bool? NodeJSCatchRejection = null; // true

        /// <summary>
        /// Whether to support async operations in the compiled code.
        /// </summary>
        public int? Asyncify = null; // 0

        /// <summary>
        /// Imports which can do a synchronous operation, in addition to the default ones that
        /// emscripten defines like emscripten_sleep.
        /// </summary>
        public string[] AsyncifyImports = null;

        /// <summary>
        /// Whether indirect calls can be on the stack during an unwind/rewind.
        /// </summary>
        public bool? AsyncifyIgnoreIndirect = null; // false

        /// <summary>
        /// The size of the asyncify stack - the region used to store unwind/rewind
        /// info.
        /// </summary>
        public int? AsyncifyStackSize = null; // 4096

        /// <summary>
        /// A list of functions that will not be instrumented by asyncify, even if it looks like they need to.
        /// </summary>
        public string[] AsyncifyRemove = null;

        /// <summary>
        /// Functions to add to the list of instrumented functions by asyncify, even if they otherwise would not be.
        /// </summary>
        public string[] AsyncifyAdd = null;

        /// <summary>
        /// Only the functions in the list will be instrumented by asyncify.
        /// </summary>
        public string[] AsyncifyOnly = null;

        /// <summary>
        /// Output which functions have been instrumented by asyncify and why.
        /// </summary>
        public bool? AsyncifyAdvise = null; // false

        /// <summary>
        /// Allows lazy code loading.
        /// </summary>
        public bool? AsyncifyLazyLoadCode = null; // false

        /// <summary>
        /// Runtime debug logging from asyncify internals.
        /// </summary>
        public int? AsyncifyDebug = null; // 0

        /// <summary>
        /// Specify which of the exports will have JSPI applied to them and return a
        /// promise.
        /// </summary>
        public string[] AsyncifyExports = null;

        /// <summary>
        /// Runtime elements that are exported on Module by default.
        /// </summary>
        public string[] ExportedRuntimeMethods = null;

        /// <summary>
        /// A list of incoming values on the Module object in JS that we care about.
        /// </summary>
        public string[] IncomingModuleJsApi = null;

        /// <summary>
        /// If set to nonzero, the provided virtual filesystem if treated
        /// case-insensitive, like Windows and macOS do.
        /// </summary>
        public bool? CaseInsensitiveFs = null; // false

        /// <summary>
        /// If set to 0, does not build in any filesystem support.
        /// </summary>
        public bool? Filesystem = null; // true

        /// <summary>
        /// Makes full filesystem support be included, even if statically it looks like
        /// it is not used.
        /// </summary>
        public bool? ForceFilesystem = null; // false

        /// <summary>
        /// Enables support for the NODERAWFS filesystem backend.
        /// </summary>
        public bool? NodeRawFs = null; // false

        /// <summary>
        /// This saves the compiled wasm module in a file with name
        /// ``$WASM_BINARY_NAME.$V8_VERSION.cached``
        /// and loads it on subsequent runs. This caches the compiled wasm code from
        /// v8 in node, which saves compiling on subsequent runs, making them start up
        /// much faster.
        /// The V8 version used in node is included in the cache name so that we don't
        /// try to load cached code from another version, which fails silently (it seems
        /// to load ok, but we do actually recompile).
        ///
        /// - The only version known to work for sure is node 12.9.1, as this has
        ///   regressed, see
        ///   https://github.com/nodejs/node/issues/18265#issuecomment-622971547
        /// - The default location of the .cached files is alongside the wasm binary,
        ///   as mentioned earlier. If that is in a read-only directory, you may need
        ///   to place them elsewhere. You can use the locateFile() hook to do so.
        ///
        /// [link]
        /// </summary>
        public bool? NodeCodeCaching = null; // false;

        /// <summary>
        /// Functions that are explicitly exported. These functions are kept alive
        /// through LLVM dead code elimination, and also made accessible outside of the
        /// generated code even after running closure compiler (on "Module").  The
        /// symbols listed here require an ``_`` prefix.
        ///
        /// By default if this setting is not specified on the command line the
        /// ``_main`` function will be implicitly exported.  In STANDALONE_WASM mode the
        /// default export is ``__start`` (or ``__initialize`` if --no-entry is specified).
        /// [link]
        /// </summary>
        public string[] ExportedFunctions = null; // []

        /// <summary>
        /// If true, we export all the symbols that are present in JS onto the Module
        /// object. This does not affect which symbols will be present - it does not
        /// prevent DCE or cause anything to be included in linking. It only does
        /// ``Module['X'] = X;``
        /// for all X that end up in the JS file. This is useful to export the JS
        /// library functions on Module, for things like dynamic linking.
        /// [link]
        /// </summary>
        public bool? ExportAll = null; // false

        /// <summary>
        /// If true, we export the symbols that are present in JS onto the Module
        /// object.
        /// It only does ``Module['X'] = X;``
        /// </summary>
        public bool? ExportKeepAlive = null; // true

        /// <summary>
        /// Remembers the values of these settings, and makes them accessible
        /// through getCompilerSetting and emscripten_get_compiler_setting.
        /// To see what is retained, look for compilerSettings in the generated code.
        /// [link]
        /// </summary>
        public bool? RetainCompilerSettings = null; // false

        /// <summary>
        /// JS library elements (C functions implemented in JS) that we include by
        /// default. If you want to make sure something is included by the JS compiler,
        /// add it here.  For example, if you do not use some ``emscripten_*`` C API call
        /// from C, but you want to call it from JS, add it here (and in EXPORTED
        /// FUNCTIONS with prefix "_", if you use closure compiler).  Note that the name
        /// may be slightly misleading, as this is for any JS library element, and not
        /// just functions. For example, you can include the Browser object by adding
        /// "$Browser" to this list.
        /// [link]
        /// </summary>
        public string[] DefaultLibraryFuncsToInclude = null; // []

        /// <summary>
        /// Include all JS library functions instead of the sum of
        /// DEFAULT_LIBRARY_FUNCS_TO_INCLUDE + any functions used by the generated code.
        /// This is needed when dynamically loading (i.e. dlopen) modules that make use
        /// of runtime library functions that are not used in the main module.  Note that
        /// this only applies to js libraries, *not* C. You will need the main file to
        /// include all needed C libraries.  For example, if a module uses malloc or new,
        /// you will need to use those in the main file too to pull in malloc for use by
        /// the module.
        /// [link]
        /// </summary>
        public bool? IncludeFullLibrary = null; // false

        /// <summary>
        /// If set to 1, we emit relocatable code from the LLVM backend; both
        /// globals and function pointers are all offset (by gb and fp, respectively)
        /// Automatically set for SIDE_MODULE or MAIN_MODULE.
        /// [compile+link]
        /// </summary>
        public bool? Relocatable = null; // false

        /// <summary>
        /// A main module is a file compiled in a way that allows us to link it to
        /// a side module at runtime.
        ///
        /// - 1: Normal main module.
        /// - 2: DCE'd main module. We eliminate dead code normally. If a side
        ///   module needs something from main, it is up to you to make sure
        ///   it is kept alive.
        ///
        /// [compile+link]
        /// </summary>
        public int? MainModule = null; // 0

        /// <summary>
        /// Corresponds to MAIN_MODULE (also supports modes 1 and 2)
        /// [compile+link]
        /// </summary>
        public int? SideModule = null; // 0

        /// <summary>
        /// Deprecated, list shared libraries directly on the command line instead.
        /// [link]
        /// </summary>
        public string[] RuntimeLinkedLibs = null; // []

        /// <summary>
        /// If set to 1, this is a worker library, a special kind of library that is run
        /// in a worker. See emscripten.h
        /// [link]
        /// </summary>
        public bool? BuildAsWorker = null; // false

        /// <summary>
        /// If set to 1, we build the project into a js file that will run in a worker,
        /// and generate an html file that proxies input and output to/from it.
        /// [link]
        /// </summary>
        public bool? ProxyToWorker = null; // false

        /// <summary>
        /// If set, the script file name the main thread loads.  Useful if your project
        /// doesn't run the main emscripten- generated script immediately but does some
        /// setup before
        /// [link]
        /// </summary>
        public string ProxyToWorkerFilename = null; // ""

        /// <summary>
        /// If set to 1, compiles in a small stub main() in between the real main() which
        /// calls pthread_create() to run the application main() in a pthread.  This is
        /// something that applications can do manually as well if they wish, this option
        /// is provided as convenience.
        ///
        /// The pthread that main() runs on is a normal pthread in all ways, with the one
        /// difference that its stack size is the same as the main thread would normally
        /// have, that is, STACK_SIZE. This makes it easy to flip between
        /// PROXY_TO_PTHREAD and non-PROXY_TO_PTHREAD modes with main() always getting
        /// the same amount of stack.
        ///
        /// This proxies Module['canvas'], if present, and if OFFSCREENCANVAS_SUPPORT
        /// is enabled. This has to happen because this is the only chance - this browser
        /// main thread does the only pthread_create call that happens on
        /// that thread, so it's the only chance to transfer the canvas from there.
        /// [link]
        /// </summary>
        public bool? ProxyToPthread = null; // false

        /// <summary>
        /// If set to 1, this file can be linked with others, either as a shared library
        /// or as the main file that calls a shared library. To enable that, we will not
        /// internalize all symbols and cull the unused ones, in other words, we will not
        /// remove unused functions and globals, which might be used by another module we
        /// are linked with.
        ///
        /// MAIN_MODULE and SIDE_MODULE both imply this, so it not normally necessary
        /// to set this explicitly. Note that MAIN_MODULE and SIDE_MODULE mode 2 do
        /// *not* set this, so that we still do normal DCE on them, and in that case
        /// you must keep relevant things alive yourself using exporting.
        /// [link]
        /// </summary>
        public bool? Linkable = null; // false

        /// <summary>
        /// Emscripten 'strict' build mode: Drop supporting any deprecated build options.
        /// Set the environment variable EMCC_STRICT=1 or pass -sSTRICT to test that a
        /// codebase builds nicely in forward compatible manner.
        /// Changes enabled by this:
        ///
        ///   - The C define EMSCRIPTEN is not defined (__EMSCRIPTEN__ always is, and
        ///     is the correct thing to use).
        ///   - STRICT_JS is enabled.
        ///   - IGNORE_MISSING_MAIN is disabled.
        ///   - AUTO_JS_LIBRARIES is disabled.
        ///   - AUTO_NATIVE_LIBRARIES is disabled.
        ///   - DEFAULT_TO_CXX is disabled.
        ///   - USE_GLFW is set to 0 rather than 2 by default.
        ///   - ALLOW_UNIMPLEMENTED_SYSCALLS is disabled.
        ///   - INCOMING_MODULE_JS_API is set to empty by default.
        /// [compile+link]
        /// </summary>
        public bool? Strict = null; // false

        /// <summary>
        /// Allow program to link with or without ``main`` symbol.
        /// If this is disabled then one must provide a ``main`` symbol or explicitly
        /// opt out by passing ``--no-entry`` or an EXPORTED_FUNCTIONS list that doesn't
        /// include ``_main``.
        /// [link]
        /// </summary>
        public bool? IgnoreMissingMain = null; // true

        /// <summary>
        /// Add ``"use strict;"`` to generated JS
        /// [link]
        /// </summary>
        public bool? StrictJs = null; // false

        /// <summary>
        /// If set to 1, we will warn on any undefined symbols that are not resolved by
        /// the ``library_*.js`` files. Note that it is common in large projects to not
        /// implement everything, when you know what is not going to actually be called
        /// (and don't want to mess with the existing buildsystem), and functions might
        /// be implemented later on, say in --pre-js, so you may want to build with -s
        /// WARN_ON_UNDEFINED_SYMBOLS=0 to disable the warnings if they annoy you.  See
        /// also ERROR_ON_UNDEFINED_SYMBOLS.  Any undefined symbols that are listed in-
        /// EXPORTED_FUNCTIONS will also be reported.
        /// [link]
        /// </summary>
        public bool? WarnOnUndefinedSymbols = null; // true

        /// <summary>
        /// If set to 1, we will give a link-time error on any undefined symbols (see
        /// WARN_ON_UNDEFINED_SYMBOLS). To allow undefined symbols at link time set this
        /// to 0, in which case if an undefined function is called a runtime error will
        /// occur.  Any undefined symbols that are listed in EXPORTED_FUNCTIONS will also
        /// be reported.
        /// [link]
        /// </summary>
        public bool? ErrorOnUndefinedSymbols = null; // true

        /// <summary>
        /// Use small chunk size for binary synchronous XHR's in Web Workers.  Used for
        /// testing.  See test_chunked_synchronous_xhr in runner.py and library.js.
        /// [link]
        /// </summary>
        public bool? SmallXhrChunks = null; // false

        /// <summary>
        /// If 1, will include shim code that tries to 'fake' a browser environment, in
        /// order to let you run a browser program (say, using SDL) in the shell.
        /// Obviously nothing is rendered, but this can be useful for benchmarking and
        /// debugging if actual rendering is not the issue. Note that the shim code is
        /// very partial - it is hard to fake a whole browser! - so keep your
        /// expectations low for this to work.
        /// [link]
        /// </summary>
        public bool? Headless = null; // false;

        /// <summary>
        /// If 1, we force Date.now(), Math.random, etc. to return deterministic results.
        /// This also tries to make execution deterministic across machines and
        /// environments, for example, not doing anything different based on the
        /// browser's language setting (which would mean you can get different results
        /// in different browsers, or in the browser and in node).
        /// Good for comparing builds for debugging purposes (and nothing else).
        /// [link]
        /// </summary>
        public bool? Deterministic = null; // false;

        /// <summary>
        /// By default we emit all code in a straightforward way into the output
        /// .js file. That means that if you load that in a script tag in a web
        /// page, it will use the global scope. With ``MODULARIZE`` set, we instead emit
        /// the code wrapped in a function that returns a promise. The promise is
        /// resolved with the module instance when it is safe to run the compiled code,
        /// similar to the ``onRuntimeInitialized`` callback. You do not need to use the
        /// ``onRuntimeInitialized`` callback when using ``MODULARIZE``.
        ///
        /// (If WASM_ASYNC_COMPILATION is off, that is, if compilation is
        /// *synchronous*, then it would not make sense to return a Promise, and instead
        /// the Module object itself is returned, which is ready to be used.)
        ///
        /// The default name of the function is ``Module``, but can be changed using the
        /// ``EXPORT_NAME`` option. We recommend renaming it to a more typical name for a
        /// factory function, e.g. ``createModule``.
        ///
        /// You use the factory function like so::
        ///
        ///   const module = await EXPORT_NAME();
        ///
        /// or::
        ///
        ///   let module;
        ///   EXPORT_NAME().then(instance => {
        ///     module = instance;
        ///   });
        ///
        ///
        /// The factory function accepts 1 parameter, an object with default values for
        /// the module instance::
        ///
        ///   const module = await EXPORT_NAME({ option: value, ... });
        ///
        /// Note the parentheses - we are calling EXPORT_NAME in order to instantiate
        /// the module. This allows you to create multiple instances of the module.
        ///
        /// Note that in MODULARIZE mode we do *not* look for a global ``Module`` object
        /// for default values. Default values must be passed as a parameter to the
        /// factory function.
        ///
        /// The default .html shell file provided in MINIMAL_RUNTIME mode will create
        /// a singleton instance automatically, to run the application on the page.
        /// (Note that it does so without using the Promise API mentioned earlier, and
        /// so code for the Promise is not even emitted in the .js file if you tell
        /// emcc to emit an .html output.)
        /// The default .html shell file provided by traditional runtime mode is only
        /// compatible with MODULARIZE=0 mode, so when building with traditional
        /// runtime, you should provided your own html shell file to perform the
        /// instantiation when building with MODULARIZE=1. (For more details, see
        /// https://github.com/emscripten-core/emscripten/issues/7950)
        ///
        /// If you add --pre-js or --post-js files, they will be included inside
        /// the factory function with the rest of the emitted code in order to be
        /// optimized together with it.
        ///
        /// If you want to include code outside all of the generated code, including the
        /// factory function, you can use --extern-pre-js or --extern-post-js. While
        /// --pre-js and --post-js happen to do that in non-MODULARIZE mode, their
        /// intended usage is to add code that is optimized with the rest of the emitted
        /// code, allowing better dead code elimination and minification.
        /// [link]
        /// </summary>
        public bool? Modularize = null; // false;

        /// <summary>
        /// Export using an ES6 Module export rather than a UMD export.  MODULARIZE must
        /// be enabled for ES6 exports and is implicitly enabled if not already set.
        ///
        /// This is implicitly enabled if the output suffix is set to 'mjs'.
        ///
        /// [link]
        /// </summary>
        public bool? ExportES6 = null; // false;

        /// <summary>
        /// Use the ES6 Module relative import feature 'import.meta.url'
        /// to auto-detect WASM Module path.
        /// It might not be supported on old browsers / toolchains. This setting
        /// may not be disabled when Node.js is targeted (-sENVIRONMENT=*node*).
        /// [link]
        /// </summary>
        public bool? UseES6ImportMeta = null; // true;

        /// <summary>
        /// Global variable to export the module as for environments without a
        /// standardized module loading system (e.g. the browser and SM shell).
        /// [link]
        /// </summary>
        public string ExportName = null; // "Module"

        /// <summary>
        /// When set to 0, we do not emit eval() and new Function(), which disables some
        /// functionality (causing runtime errors if attempted to be used), but allows
        /// the emitted code to be acceptable in places that disallow dynamic code
        /// execution (chrome packaged app, privileged firefox app, etc.). Pass this flag
        /// when developing an Emscripten application that is targeting a privileged or a
        /// certified execution environment, see Firefox Content Security Policy (CSP)
        /// webpage for details:
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/script-src
        /// in particular the 'unsafe-eval' and 'wasm-unsafe-eval' policies.
        ///
        /// When this flag is set, the following features (linker flags) are unavailable:
        ///
        ///  - RELOCATABLE: the function loadDynamicLibrary would need to eval().
        ///
        /// and some features may fall back to slower code paths when they need to:
        /// Embind: uses eval() to jit functions for speed.
        ///
        /// Additionally, the following Emscripten runtime functions are unavailable when
        /// DYNAMIC_EXECUTION=0 is set, and an attempt to call them will throw an exception:
        ///
        /// - emscripten_run_script(),
        /// - emscripten_run_script_int(),
        /// - emscripten_run_script_string(),
        /// - dlopen(),
        /// - the functions ccall() and cwrap() are still available, but they are
        ///   restricted to only being able to call functions that have been exported in
        ///   the Module object in advance.
        ///
        /// When -sDYNAMIC_EXECUTION=2 is set, attempts to call to eval() are demoted to
        /// warnings instead of throwing an exception.
        /// [link]
        /// </summary>
        public int? DynamicExecution = null; // 1;

        /// <summary>
        /// whether we are in the generate struct_info bootstrap phase
        /// [link]
        /// </summary>
        public bool? BootstrappingStructInfo = null; // false;

        /// <summary>
        /// Add some calls to emscripten tracing APIs
        /// [compile+link]
        /// </summary>
        public bool? EmscriptenTracing = null; // false;

        /// <summary>
        /// Specify the GLFW version that is being linked against.  Only relevant, if you
        /// are linking against the GLFW library.  Valid options are 2 for GLFW2 and 3
        /// for GLFW3.
        /// [link]
        /// </summary>
        public int? UseGLFW = null; // 0;

        /// <summary>
        /// Whether to use compile code to WebAssembly. Set this to 0 to compile to JS
        /// instead of wasm.
        ///
        /// Specify -sWASM=2 to target both WebAssembly and JavaScript at the same time.
        /// In that build mode, two files a.wasm and a.wasm.js are produced, and at runtime
        /// the WebAssembly file is loaded if browser/shell supports it. Otherwise the
        /// .wasm.js fallback will be used.
        ///
        /// If WASM=2 is enabled and the browser fails to compile the WebAssembly module,
        /// the page will be reloaded in Wasm2JS mode.
        /// [link]
        /// </summary>
        public int? WASM = null; // 1;

        /// <summary>
        /// STANDALONE_WASM indicates that we want to emit a wasm file that can run
        /// without JavaScript. The file will use standard APIs such as wasi as much as
        /// possible to achieve that.
        ///
        /// This option does not guarantee that the wasm can be used by itself - if you
        /// use APIs with no non-JS alternative, we will still use those (e.g., OpenGL
        /// at the time of writing this). This gives you the option to see which APIs
        /// are missing, and if you are compiling for a custom wasi embedding, to add
        /// those to your embedding.
        ///
        /// We may still emit JS with this flag, but the JS should only be a convenient
        /// way to run the wasm on the Web or in Node.js, and you can run the wasm by
        /// itself without that JS (again, unless you use APIs for which there is no
        /// non-JS alternative) in a wasm runtime like wasmer or wasmtime.
        ///
        /// Note that even without this option we try to use wasi etc. syscalls as much
        /// as possible. What this option changes is that we do so even when it means
        /// a tradeoff with JS size. For example, when this option is set we do not
        /// import the Memory - importing it is useful for JS, so that JS can start to
        /// use it before the wasm is even loaded, but in wasi and other wasm-only
        /// environments the expectation is to create the memory in the wasm itself.
        /// Doing so prevents some possible JS optimizations, so we only do it behind
        /// this flag.
        ///
        /// When this flag is set we do not legalize the JS interface, since the wasm is
        /// meant to run in a wasm VM, which can handle i64s directly. If we legalized it
        /// the wasm VM would not recognize the API. However, this means that the
        /// optional JS emitted won't run if you use a JS API with an i64. You can use
        /// the WASM_BIGINT option to avoid that problem by using BigInts for i64s which
        /// means we don't need to legalize for JS (but this requires a new enough JS
        /// VM).
        ///
        /// Standalone builds require a ``main`` entry point by default.  If you want to
        /// build a library (also known as a reactor) instead you can pass ``--no-entry``.
        /// [link]
        /// </summary>
        public bool? StandaloneWasm = null; // false;

        /// <summary>
        /// Whether to ignore implicit traps when optimizing in binaryen.  Implicit
        /// traps are the traps that happen in a load that is out of bounds, or
        /// div/rem of 0, etc. With this option set, the optimizer assumes that loads
        /// cannot trap, and therefore that they have no side effects at all. This
        /// is *not* safe in general, as you may have a load behind a condition which
        /// ensures it it is safe; but if the load is assumed to not have side effects it
        /// could be executed unconditionally. For that reason this option is generally
        /// not useful on large and complex projects, but in a small and simple enough
        /// codebase it may help reduce code size a little bit.
        /// [link]
        /// </summary>
        public bool? BinaryenIgnoreImplicitTraps = null; // false;

        /// <summary>
        /// A comma-separated list of extra passes to run in the binaryen optimizer,
        /// Setting this does not override/replace the default passes. It is appended at
        /// the end of the list of passes.
        /// [link]
        /// </summary>
        public string? BinaryenExtraPasses = null; // "";

        /// <summary>
        /// Whether to compile the wasm asynchronously, which is more efficient and does
        /// not block the main thread. This is currently required for all but the
        /// smallest modules to run in chrome.
        ///
        /// (This option was formerly called BINARYEN_ASYNC_COMPILATION)
        /// [link]
        /// </summary>
        public bool? WasmAsyncCompilation = null; // true;

        /// <summary>
        /// If set to 1, the dynCall() and dynCall_sig() API is made available
        /// to caller.
        /// [link]
        /// </summary>
        public bool? DynCalls = null; // false;

        /// <summary>
        /// WebAssembly integration with JavaScript BigInt. When enabled we don't need to
        /// legalize i64s into pairs of i32s, as the wasm VM will use a BigInt where an
        /// i64 is used. If WASM_BIGINT is present, the default minimum supported browser
        /// versions will be increased to the min version that supports BigInt.
        /// [link]
        /// </summary>
        public bool? WasmBigInt = null; // false;

        /// <summary>
        /// WebAssembly defines a "producers section" which compilers and tools can
        /// annotate themselves in, and LLVM emits this by default.
        /// Emscripten will strip that out so that it is *not* emitted because it
        /// increases code size, and also some users may not want information
        /// about their tools to be included in their builds for privacy or security
        /// reasons, see
        /// https://github.com/WebAssembly/tool-conventions/issues/93.
        /// [link]
        /// </summary>
        public bool? EmitProducersSection = null; //false

        /// <summary>
        /// Emits emscripten license info in the JS output.
        /// [link]
        /// </summary>
        public bool? EmitEmscriptenLicense = null; //false

        /// <summary>
        /// Whether to legalize the JS FFI interfaces (imports/exports) by wrapping them
        /// to automatically demote i64 to i32 and promote f32 to f64. This is necessary
        /// in order to interface with JavaScript.  For non-web/non-JS embeddings, setting
        /// this to 0 may be desirable.
        /// [link]
        /// </summary>
        public bool? LegalizeJsFfi = null; //true

        /// <summary>
        /// Specify the SDL version that is being linked against.
        /// 1, the default, is 1.3, which is implemented in JS
        /// 2 is a port of the SDL C code on emscripten-ports
        /// When AUTO_JS_LIBRARIES is set to 0 this defaults to 0 and SDL
        /// is not linked in.
        /// Alternate syntax for using the port: --use-port=sdl2
        /// [compile+link]
        /// </summary>
        public int? UseSDL = null; //0

        /// <summary>
        /// Specify the SDL_gfx version that is being linked against. Must match USE_SDL
        /// [compile+link]
        /// </summary>
        public int? UseSDLGfx = null; //0

        /// <summary>
        /// Specify the SDL_image version that is being linked against. Must match USE_SDL
        /// [compile+link]
        /// </summary>
        public int? UseSDLImage = null; //1

        /// <summary>
        /// Specify the SDL_ttf version that is being linked against. Must match USE_SDL
        /// [compile+link]
        /// </summary>
        public int? UseSDLTtf = null; //1

        /// <summary>
        /// Specify the SDL_net version that is being linked against. Must match USE_SDL
        /// [compile+link]
        /// </summary>
        public int? UseSDLNet = null; //1

        /// <summary>
        /// 1 = use icu from emscripten-ports
        /// Alternate syntax: --use-port=icu
        /// [compile+link]
        /// </summary>
        public bool? UseICU = null; //false

        /// <summary>
        /// 1 = use zlib from emscripten-ports
        /// Alternate syntax: --use-port=zlib
        /// [compile+link]
        /// </summary>
        public bool? UseZlib = null; //false

        /// <summary>
        /// 1 = use bzip2 from emscripten-ports
        /// Alternate syntax: --use-port=bzip2
        /// [compile+link]
        /// </summary>
        public bool? UseBzip2 = null; //false

        /// <summary>
        /// 1 = use giflib from emscripten-ports
        /// Alternate syntax: --use-port=giflib
        /// [compile+link]
        /// </summary>
        public bool? UseGiflib = null; //false

        /// <summary>
        /// 1 = use libjpeg from emscripten-ports
        /// Alternate syntax: --use-port=libjpeg
        /// [compile+link]
        /// </summary>
        public bool? UseLibjpeg = null; //false

        /// <summary>
        /// 1 = use libpng from emscripten-ports
        /// Alternate syntax: --use-port=libpng
        /// [compile+link]
        /// </summary>
        public bool? UseLibpng = null; //false

        /// <summary>
        /// 1 = use Regal from emscripten-ports
        /// Alternate syntax: --use-port=regal
        /// [compile+link]
        /// </summary>
        public bool? UseRegal = null; //false

        /// <summary>
        /// 1 = use Boost headers from emscripten-ports
        /// Alternate syntax: --use-port=boost_headers
        /// [compile+link]
        /// </summary>
        public bool? UseBoostHeaders = null; //false

        /// <summary>
        /// 1 = use bullet from emscripten-ports
        /// Alternate syntax: --use-port=bullet
        /// [compile+link]
        /// </summary>
        public bool? UseBullet = null; //false

        /// <summary>
        /// 1 = use vorbis from emscripten-ports
        /// Alternate syntax: --use-port=vorbis
        /// [compile+link]
        /// </summary>
        public bool? UseVorbis = null; //false

        /// <summary>
        /// 1 = use ogg from emscripten-ports
        /// Alternate syntax: --use-port=ogg
        /// [compile+link]
        /// </summary>
        public bool? UseOgg = null; // Default: false

        /// <summary>
        /// 1 = use mpg123 from emscripten-ports
        /// Alternate syntax: --use-port=mpg123
        /// [compile+link]
        /// </summary>
        public bool? UseMpg123 = null; // Default: false

        /// <summary>
        /// 1 = use freetype from emscripten-ports
        /// Alternate syntax: --use-port=freetype
        /// [compile+link]
        /// </summary>
        public bool? UseFreetype = null; // Default: false

        /// <summary>
        /// Specify the SDL_mixer version that is being linked against.
        /// Doesn't *have* to match UseSDL, but a good idea.
        /// [compile+link]
        /// </summary>
        public int? UseSdlMixer = null; // Default: 1

        /// <summary>
        /// 1 = use harfbuzz from harfbuzz upstream
        /// Alternate syntax: --use-port=harfbuzz
        /// [compile+link]
        /// </summary>
        public bool? UseHarfbuzz = null; // Default: false

        /// <summary>
        /// 3 = use cocos2d v3 from emscripten-ports
        /// Alternate syntax: --use-port=cocos2d
        /// [compile+link]
        /// </summary>
        public int? UseCocos2D = null; // Default: 0

        /// <summary>
        /// 1 = use libmodplug from emscripten-ports
        /// Alternate syntax: --use-port=libmodplug
        /// [compile+link]
        /// </summary>
        public bool? UseModplug = null; // Default: false

        /// <summary>
        /// Formats to support in SDL2_image. Valid values: bmp, gif, lbm, pcx, png, pnm,
        /// tga, xcf, xpm, xv
        /// [link]
        /// </summary>
        public string[] SDL2ImageFormats = null; // Default: []

        /// <summary>
        /// Formats to support in SDL2_mixer. Valid values: ogg, mp3, mod, mid
        /// [link]
        /// </summary>
        public string[] SDL2MixerFormats = null; // Default: ["ogg"]

        /// <summary>
        /// 1 = use sqlite3 from emscripten-ports
        /// Alternate syntax: --use-port=sqlite3
        /// [compile+link]
        /// </summary>
        public bool? UseSqlite3 = null; // Default: false

        /// <summary>
        /// If 1, target compiling a shared Wasm Memory.
        /// [compile+link] - affects user code at compile and system libraries at link.
        /// </summary>
        public bool? SharedMemory = null; // Default: false

        /// <summary>
        /// If true, enables support for Wasm Workers. Wasm Workers enable applications
        /// to create threads using a lightweight web-specific API that builds on top
        /// of Wasm SharedArrayBuffer + Atomics API.
        /// [compile+link] - affects user code at compile and system libraries at link.
        /// </summary>
        public bool? WasmWorkers = null; // Default: false

        /// <summary>
        /// If true, enables targeting Wasm Web Audio AudioWorklets. Check out the
        /// full documentation in site/source/docs/api_reference/wasm_audio_worklets.rst
        /// [link]
        /// </summary>
        public bool? AudioWorklet = null; // Default: false

        /// <summary>
        /// If true, enables deep debugging of Web Audio backend.
        /// [link]
        /// </summary>
        public bool? WebAudioDebug = null; // Default: false

        /// <summary>
        /// In web browsers, Workers cannot be created while the main browser thread
        /// is executing JS/Wasm code, but the main thread must regularly yield back
        /// to the browser event loop for Worker initialization to occur.
        /// This means that pthread_create() is essentially an asynchronous operation
        /// when called from the main browser thread, and the main thread must
        /// repeatedly yield back to the JS event loop in order for the thread to
        /// actually start.
        /// If your application needs to be able to synchronously create new threads,
        /// you can pre-create a pthread pool by specifying -sPTHREAD_POOL_SIZE=x,
        /// in which case the specified number of Workers will be preloaded into a pool
        /// before the application starts, and that many threads can then be available
        /// for synchronous creation.
        /// Note that this setting is a string, and will be emitted in the JS code
        /// (directly, with no extra quotes) so that if you set it to '5' then 5 workers
        /// will be used in the pool, and so forth. The benefit of this being a string
        /// is that you can set it to something like
        /// 'navigator.hardwareConcurrency' (which will use the number of cores the
        /// browser reports, and is how you can get exactly enough workers for a
        /// threadpool equal to the number of cores).
        /// [link] - affects generated JS runtime code at link time
        /// </summary>
        public string PthreadPoolSize = null; // Default: 0

        /// <summary>
        /// Normally, applications can create new threads even when the pool is empty.
        /// When application breaks out to the JS event loop before trying to block on
        /// the thread via ``pthread_join`` or any other blocking primitive,
        /// an extra Worker will be created and the thread callback will be executed.
        /// However, breaking out to the event loop requires custom modifications to
        /// the code to adapt it to the Web, and not something that works for
        /// off-the-shelf apps. Those apps without any modifications are most likely
        /// to deadlock. This setting ensures that, instead of a risking a deadlock,
        /// they get a runtime EAGAIN error instead that can at least be gracefully
        /// handled from the C / C++ side.
        /// Values:
        ///
        /// - ``0`` - disable warnings on thread pool exhaustion
        /// - ``1`` - enable warnings on thread pool exhaustion (default)
        /// - ``2`` - make thread pool exhaustion a hard error
        ///
        /// [link]
        /// </summary>
        public int? PthreadPoolSizeStrict = null; // Default: 1

        /// <summary>
        /// If your application does not need the ability to synchronously create
        /// threads, but it would still like to opportunistically speed up initial thread
        /// startup time by prewarming a pool of Workers, you can specify the size of
        /// the pool with -sPTHREAD_POOL_SIZE=x, but then also specify
        /// -sPTHREAD_POOL_DELAY_LOAD, which will cause the runtime to not wait up at
        /// startup for the Worker pool to finish loading. Instead, the runtime will
        /// immediately start up and the Worker pool will asynchronously spin up in
        /// parallel on the background. This can shorten the time that pthread_create()
        /// calls take to actually start a thread, but without actually slowing down
        /// main application startup speed. If PTHREAD_POOL_DELAY_LOAD=0 (default),
        /// then the runtime will wait for the pool to start up before running main().
        /// If you do need to synchronously wait on the created threads
        /// (e.g. via pthread_join), you must wait on the Module.pthreadPoolReady
        /// promise before doing so or you're very likely to run into deadlocks.
        /// [link] - affects generated JS runtime code at link time
        /// </summary>
        public bool? PthreadPoolDelayLoad = null; // Default: false

        /// <summary>
        /// Default stack size to use for newly created pthreads.  When not set, this
        /// defaults to STACK_SIZE (which in turn defaults to 64k).  Can also be set at
        /// runtime using pthread_attr_setstacksize().  Note that the wasm control flow
        /// stack is separate from this stack.  This stack only contains certain function
        /// local variables, such as those that have their addresses taken, or ones that
        /// are too large to fit as local vars in wasm code.
        /// [link]
        /// </summary>
        public int? DefaultPthreadStackSize = null; // Default: 0

        /// <summary>
        /// True when building with --threadprofiler
        /// [link]
        /// </summary>
        public bool? PthreadsProfiling = null; // Default: false

        /// <summary>
        /// It is dangerous to call pthread_join or pthread_cond_wait
        /// on the main thread, as doing so can cause deadlocks on the Web (and also
        /// it works using a busy-wait which is expensive). See
        /// https://emscripten.org/docs/porting/pthreads.html#blocking-on-the-main-browser-thread
        /// This may become set to 0 by default in the future; for now, this just
        /// warns in the console.
        /// [link]
        /// </summary>
        public bool? AllowBlockingOnMainThread = null; // Default: true

        /// <summary>
        /// If true, add in debug traces for diagnosing pthreads related issues.
        /// [link]
        /// </summary>
        public bool? PthreadsDebug = null; // Default: false

        /// <summary>
        /// This tries to evaluate code at compile time. The main use case is to eval
        /// global ctor functions, which are those that run before main(), but main()
        /// itself or parts of it can also be evalled. Evaluating code this way can avoid
        /// work at runtime, as it applies the results of the execution to memory and
        /// globals and so forth, "snapshotting" the wasm and then just running it from
        /// there when it is loaded.
        ///
        /// This will stop when it sees something it cannot eval at compile time, like a
        /// call to an import. When running with this option you will see logging that
        /// indicates what is evalled and where it stops.
        ///
        /// This optimization can either reduce or increase code size. If a small amount
        /// of code generates many changes in memory, for example, then overall size may
        /// increase.
        ///
        /// LLVM's GlobalOpt *almost* does this operation. It does in simple cases, where
        /// LLVM IR is not too complex for its logic to evaluate, but it isn't powerful
        /// enough for e.g. libc++ iostream ctors. It is just hard to do at the LLVM IR
        /// level - LLVM IR is complex and getting more complex, so this would require
        /// GlobalOpt to have a full interpreter, plus a way to write back into LLVM IR
        /// global objects.  At the wasm level, however, everything has been lowered
        /// into a simple low level, and we also just need to write bytes into an array,
        /// so this is easy for us to do. A further issue for LLVM is that it doesn't
        /// know that we will not link in further code, so it only tries to optimize
        /// ctors with lowest priority (while we do know explicitly if dynamic linking is
        /// enabled or not).
        ///
        /// If set to a value of 2, this also makes some "unsafe" assumptions,
        /// specifically that there is no input received while evalling ctors. That means
        /// we ignore args to main() as well as assume no environment vars are readable.
        /// This allows more programs to be optimized, but you need to make sure your
        /// program does not depend on those features - even just checking the value of
        /// argc can lead to problems.
        ///
        /// [link]
        /// </summary>
        public int? EvalCtors = null; // Default: 0

        /// <summary>
        /// Is enabled, use the JavaScript TextDecoder API for string marshalling.
        /// Enabled by default, set this to 0 to disable.
        /// If set to 2, we assume TextDecoder is present and usable, and do not emit
        /// any JS code to fall back if it is missing. In single threaded -Oz build modes,
        /// TEXTDECODER defaults to value == 2 to save code size.
        /// [link]
        /// </summary>
        public int? TextDecoder = null; // Default: 1














        /// <summary>
        /// Embind specific: If enabled, assume UTF-8 encoded data in std::string binding.
        /// Disable this to support binary data transfer.
        /// </summary>
        public bool? EmbindStdStringIsUtf8 = null; // Default: true

        /// <summary>
        /// Embind specific: If enabled, generate Embind's JavaScript invoker functions
        /// at compile time and include them in the JS output file. When used with
        /// DYNAMIC_EXECUTION=0 this allows exported bindings to be just as fast as
        /// DYNAMIC_EXECUTION=1 mode, but without the need for eval(). If there are many
        /// bindings the JS output size may be larger though.
        /// </summary>
        public bool? EmbindAot = null; // Default: false

        /// <summary>
        /// If set to 1, enables support for transferring canvases to pthreads and
        /// creating WebGL contexts in them, as well as explicit swap control for GL
        /// contexts. This needs browser support for the OffscreenCanvas specification.
        /// </summary>
        public bool? OffscreenCanvasSupport = null; // Default: false

        /// <summary>
        /// If you are using PROXY_TO_PTHREAD with OFFSCREENCANVAS_SUPPORT, then specify
        /// here a comma separated list of CSS ID selectors to canvases to proxy over
        /// to the pthread at program startup, e.g. '#canvas1, #canvas2'.
        /// </summary>
        public string OffscreenCanvasesToPthread = null; // Default: "#canvas"

        /// <summary>
        /// If set to 1, enables support for WebGL contexts to render to an offscreen
        /// render target, to avoid the implicit swap behavior of WebGL where exiting any
        /// event callback would automatically perform a "flip" to present rendered
        /// content on screen. When an Emscripten GL context has Offscreen Framebuffer
        /// enabled, a single frame can be composited from multiple event callbacks, and
        /// the swap function emscripten_webgl_commit_frame() is then explicitly called
        /// to present the rendered content on screen.
        /// </summary>
        public bool? OffscreenFramebuffer = null; // Default: false

        /// <summary>
        /// If nonzero, Fetch API supports backing to IndexedDB. If 0, IndexedDB is not
        /// utilized. Set to 0 if IndexedDB support is not interesting for target
        /// application, to save a few kBytes.
        /// </summary>
        public bool? FetchSupportIndexedDB = null; // Default: true

        /// <summary>
        /// If nonzero, prints out debugging information in library_fetch.js
        /// </summary>
        public bool? FetchDebug = null; // Default: false

        /// <summary>
        /// If nonzero, enables emscripten_fetch API.
        /// </summary>
        public bool? Fetch = null; // Default: false

        /// <summary>
        /// ATTENTION [WIP]: Experimental feature. Please use at your own risk.
        /// This will eventually replace the current JS file system implementation.
        /// If set to 1, uses new filesystem implementation.
        /// [experimental]
        /// </summary>
        public bool? Wasmfs = null; // Default: false

        /// <summary>
        /// If set to 1, embeds all subresources in the emitted file as base64 string
        /// literals. Embedded subresources may include (but aren't limited to) wasm,
        /// asm.js, and static memory initialization code.
        /// </summary>
        public bool? SingleFile = null; // Default: false

        /// <summary>
        /// If set to 1, all JS libraries will be automatically available at link time.
        /// This gets set to 0 in STRICT mode (or with MINIMAL_RUNTIME) which mean you
        /// need to explicitly specify -lfoo.js in at link time in order to access
        /// library function in library_foo.js.
        /// </summary>
        public bool? AutoJsLibraries = null; // Default: true

        /// <summary>
        /// Like AUTO_JS_LIBRARIES but for the native libraries such as libgl, libal
        /// and libhtml5.   If this is disabled it is necessary to explicitly add
        /// e.g. -lhtml5 and also to first build the library using ``embuilder``.
        /// </summary>
        public bool? AutoNativeLibraries = null; // Default: true

        /// <summary>
        /// Specifies the oldest major version of Firefox to target. I.e. all Firefox
        /// versions >= MIN_FIREFOX_VERSION
        /// are desired to work. Pass -sMIN_FIREFOX_VERSION=majorVersion to drop support
        /// for Firefox versions older than < majorVersion.
        /// Firefox 79 was released on 2020-07-28.
        /// MAX_INT (0x7FFFFFFF, or -1) specifies that target is not supported.
        /// Minimum supported value is 34 which was released on 2014-12-01.
        /// </summary>
        public int? MinFirefoxVersion = null; // Default: 79

        /// <summary>
        /// Specifies the oldest version of desktop Safari to target. Version is encoded
        /// in MMmmVV, e.g. 70101 denotes Safari
        /// </summary>
        public int? MinSafariVersion = null; // Default: 140100

        /// <summary>
        /// Specifies the oldest version of Chrome. E.g. pass -sMIN_CHROME_VERSION=58 to
        /// drop support for Chrome 57 and older.
        /// This setting also applies to modern Chromium-based Edge, which shares version
        /// numbers with Chrome.
        /// Chrome 85 was released on 2020-08-25.
        /// MAX_INT (0x7FFFFFFF, or -1) specifies that target is not supported.
        /// Minimum supported value is 32, which was released on 2014-01-04.
        /// [link]
        /// </summary>
        public int? MinChromeVersion = null; // 85

        /// <summary>
        /// Specifies minimum node version to target for the generated code.  This is
        /// distinct from the minimum version required run the emscripten compiler.
        /// This version aligns with the current Ubuuntu TLS 20.04 (Focal).
        /// Version is encoded in MMmmVV, e.g. 181401 denotes Node 18.14.01.
        /// Minimum supported value is 101900, which was released 2020-02-05.
        /// </summary>
        public int? MinNodeVersion = null; // 160000

        /// <summary>
        /// Whether we support setting errno from JS library code.
        /// In MINIMAL_RUNTIME builds, this option defaults to 0.
        /// [link]
        /// [deprecated]
        /// </summary>
        public bool? SupportErrno = null; // true

        /// <summary>
        /// If true, uses minimal sized runtime without POSIX features, Module,
        /// preRun/preInit/etc., Emscripten built-in XHR loading or library_browser.js.
        /// Enable this setting to target the smallest code size possible.  Set
        /// MINIMAL_RUNTIME=2 to further enable even more code size optimizations. These
        /// opts are quite hacky, and work around limitations in Closure and other parts
        /// of the build system, so they may not work in all generated programs (But can
        /// be useful for really small programs).
        ///
        /// By default, no symbols will be exported on the ``Module`` object. In order
        /// to export kept alive symbols, please use ``-sEXPORT_KEEPALIVE=1``.
        /// [link]
        /// </summary>
        public int? MinimalRuntime = null; // 0

        /// <summary>
        /// If set to 1, MINIMAL_RUNTIME will utilize streaming WebAssembly compilation,
        /// where WebAssembly module is compiled already while it is being downloaded.
        /// In order for this to work, the web server MUST properly serve the .wasm file
        /// with a HTTP response header "Content-Type: application/wasm". If this HTTP
        /// header is not present, e.g. Firefox 73 will fail with an error message
        /// ``TypeError: Response has unsupported MIME type``
        /// and Chrome 78 will fail with an error message
        /// `Uncaught (in promise) TypeError: Failed to execute 'compile' on
        /// 'WebAssembly': Incorrect response MIME type. Expected 'application/wasm'`.
        /// If set to 0 (default), streaming WebAssembly compilation is disabled, which
        /// means that the WebAssembly Module will first be downloaded fully, and only
        /// then compilation starts.
        /// For large .wasm modules and production environments, this should be set to 1
        /// for faster startup speeds. However this setting is disabled by default
        /// since it requires server side configuration and for really small pages there
        /// is no observable difference (also has a ~100 byte impact to code size)
        /// [link]
        /// </summary>
        public bool? MinimalRuntimeStreamingWasmCompilation = null; // false

        /// <summary>
        /// If set to 1, MINIMAL_RUNTIME will utilize streaming WebAssembly instantiation,
        /// where WebAssembly module is compiled+instantiated already while it is being
        /// downloaded. Same restrictions/requirements apply as with
        /// MINIMAL_RUNTIME_STREAMING_WASM_COMPILATION.
        /// MINIMAL_RUNTIME_STREAMING_WASM_COMPILATION and
        /// MINIMAL_RUNTIME_STREAMING_WASM_INSTANTIATION cannot be simultaneously active.
        /// Which one of these two is faster depends on the size of the wasm module,
        /// the size of the JS runtime file, and the size of the preloaded data file
        /// to download, and the browser in question.
        /// [link]
        /// </summary>
        public bool? MinimalRuntimeStreamingWasmInstantiation = null; // false

        /// <summary>
        /// If set to 'emscripten' or 'wasm', compiler supports setjmp() and longjmp().
        /// If set to 0, these APIs are not available.  If you are using C++ exceptions,
        /// but do not need setjmp()+longjmp() API, then you can set this to 0 to save a
        /// little bit of code size and performance when catching exceptions.
        ///
        /// 'emscripten': (default) Emscripten setjmp/longjmp handling using JavaScript
        /// 'wasm': setjmp/longjmp handling using Wasm EH instructions (experimental)
        ///
        /// - 0: No setjmp/longjmp handling
        /// - 1: Default setjmp/longjmp/handling, depending on the mode of exceptions.
        ///   'wasm' if '-fwasm-exception' is used, 'emscripten' otherwise.
        ///
        /// [compile+link] - at compile time this enables the transformations needed for
        /// longjmp support at codegen time, while at link it allows linking in the
        /// library support.
        /// </summary>
        public bool? SupportLongjmp = null; // true

        /// <summary>
        /// If set to 1, disables old deprecated HTML5 API event target lookup behavior.
        /// When enabled, there is no "Module.canvas" object, no magic "null" default
        /// handling, and DOM element 'target' parameters are taken to refer to CSS
        /// selectors, instead of referring to DOM IDs.
        /// [link]
        /// </summary>
        public bool? DisableDeprecatedFindEventTargetBehavior = null; // true

        /// <summary>
        /// Certain browser DOM API operations, such as requesting fullscreen mode
        /// transition or pointer lock require that the request originates from within
        /// an user initiated event, such as mouse click or keyboard press. Refactoring
        /// an application to follow this kind of program structure can be difficult, so
        /// HTML5_SUPPORT_DEFERRING_USER_SENSITIVE_REQUESTS=1 flag allows transparent
        /// emulation of this by deferring synchronous fullscreen mode and pointer lock
        /// requests until a suitable event callback is generated. Set this to 0
        /// to disable support for deferring to save code space if your application does
        /// not need support for deferred calls.
        /// [link]
        /// </summary>
        public bool? Html5SupportDeferringUserSensitiveRequests = null; // true

        /// <summary>
        /// Specifies whether the generated .html file is run through html-minifier. The
        /// set of optimization passes run by html-minifier depends on debug and
        /// optimization levels. In -g2 and higher, no minification is performed. In -g1,
        /// minification is done, but whitespace is retained. Minification requires at
        /// least -O1 or -Os to be used. Pass -sMINIFY_HTML=0 to explicitly choose to
        /// disable HTML minification altogether.
        /// [link]
        /// </summary>
        public bool? MinifyHtml = null; // true

        /// <summary>
        /// Whether we *may* be using wasm2js. This compiles to wasm normally, but lets
        /// you run wasm2js *later* on the wasm, and you can pick between running the
        /// normal wasm or that wasm2js code. For details of how to do that, see the
        /// test_maybe_wasm2js test.  This option can be useful for debugging and
        /// bisecting.
        /// [link]
        /// </summary>
        public bool? MaybeWasm2Js = null; // false

        /// <summary>
        /// This option is no longer used. The appropriate shadow memory size is now
        /// calculated from INITIAL_MEMORY and MAXIMUM_MEMORY. Will be removed in a
        /// future release.
        /// [link]
        /// </summary>
        public int? AsanShadowSize = null; // -1

        /// <summary>
        /// Whether we should use the offset converter.  This is needed for older
        /// versions of v8 (<7.7) that does not give the hex module offset into wasm
        /// binary in stack traces, as well as for avoiding using source map entries
        /// across function boundaries.
        /// [link]
        /// </summary>
        public bool? UseOffsetConverter = null; // false

        /// <summary>
        /// Whether we should load the WASM source map at runtime.
        /// This is enabled automatically when using -gsource-map with sanitizers.
        /// </summary>
        public bool? LoadSourceMap = null; // false

        /// <summary>
        /// Default to c++ mode even when run as ``emcc`` rather then ``emc++``.
        /// When this is disabled ``em++`` is required linking C++ programs. Disabling
        /// this will match the behaviour of gcc/g++ and clang/clang++.
        /// [link]
        /// </summary>
        public bool? DefaultToCxx = null; // true

        /// <summary>
        /// While LLVM's wasm32 has long double = float128, we don't support printing
        /// that at full precision by default. Instead we print as 64-bit doubles, which
        /// saves libc code size. You can flip this option on to get a libc with full
        /// long double printing precision.
        /// [link]
        /// </summary>
        public bool? PrintfLongDouble = null; // false

        /// <summary>
        /// Setting this affects the path emitted in the wasm that refers to the DWARF
        /// file, in -gseparate-dwarf mode. This allows the debugging file to be hosted
        /// in a custom location.
        /// [link]
        /// </summary>
        public string SeparateDwarfUrl = null; // ''

        /// <summary>
        /// Emscripten runs wasm-ld to link, and in some cases will do further changes to
        /// the wasm afterwards, like running wasm-opt to optimize the binary in
        /// optimized builds. However, in some builds no wasm changes are necessary after
        /// link. This can make the entire link step faster, and can also be important
        /// for other reasons, like in debugging if the wasm is not modified then the
        /// DWARF info from LLVM is preserved (wasm-opt can rewrite it in some cases, but
        /// not in others like split-dwarf).
        /// When this flag is turned on, we error at link time if the build requires any
        /// changes to the wasm after link. This can be useful in testing, for example.
        /// Some example of features that require post-link wasm changes are:
        /// - Lowering i64 to i32 pairs at the JS boundary (See WASM_BIGINT)
        /// - Lowering sign-extension operation when targeting older browsers.
        /// </summary>
        public bool? ErrorOnWasmChangesAfterLink = null; // false

        /// <summary>
        /// Abort on unhandled excptions that occur when calling exported WebAssembly
        /// functions. This makes the program behave more like a native program where the
        /// OS would terminate the process and no further code can be executed when an
        /// unhandled exception (e.g. out-of-bounds memory access) happens.
        /// This will instrument all exported functions to catch thrown exceptions and
        /// call abort() when they happen. Once the program aborts any exported function
        /// calls will fail with a "program has already aborted" exception to prevent
        /// calls into code with a potentially corrupted program state.
        /// This adds a small fixed amount to code size in optimized builds and a slight
        /// overhead for the extra instrumented function indirection.  Enable this if you
        /// want Emscripten to handle unhandled exceptions nicely at the cost of a few
        /// bytes extra.
        /// Exceptions that occur within the ``main`` function are already handled via an
        /// alternative mechanimsm.
        /// [link]
        /// </summary>
        public bool? AbortOnWasmExceptions = null; // false

        /// <summary>
        /// Build binaries that use as many WASI APIs as possible, and include additional
        /// JS support libraries for those APIs.  This allows emscripten to produce binaries
        /// are more WASI compliant and also allows it to process and execute WASI
        /// binaries built with other SDKs (e.g.  wasi-sdk).
        /// This setting is experimental and subject to change or removal.
        /// Implies STANDALONE_WASM.
        /// [link]
        /// [experimental]
        /// </summary>
        public bool? PureWasi = null; // false

        /// <summary>
        /// Set to 1 to define the WebAssembly.Memory object outside of the wasm
        /// module.  By default the wasm module defines the memory and exports
        /// it to JavaScript.
        /// Use of the following settings will enable this settings since they
        /// depend on being able to define the memory in JavaScript:
        /// - -pthread
        /// - RELOCATABLE
        /// - ASYNCIFY_LAZY_LOAD_CODE
        /// - WASM2JS (WASM=0)
        /// [link]
        /// </summary>
        public bool? ImportedMemory = null; // false;

        /// <summary>
        /// Generate code to loading split wasm modules.
        /// This option will automatically generate two wasm files as output, one
        /// with the ``.orig`` suffix and one without.  The default file (without
        /// the suffix) when run will generate instrumentation data can later be
        /// fed into wasm-split (the binaryen tool).
        /// As well as this the generated JS code will contains help functions
        /// to loading split modules.
        /// [link]
        /// </summary>
        public bool? SplitModule = null; // false;

        /// <summary>
        /// For MAIN_MODULE builds, automatically load any dynamic library dependencies
        /// on startup, before loading the main module.
        /// </summary>
        public bool? AutoloadDylibs = null; // true;

        /// <summary>
        /// Include unimplemented JS syscalls to be included in the final output.  This
        /// allows programs that depend on these syscalls at runtime to be compiled, even
        /// though these syscalls will fail (or do nothing) at runtime.
        /// </summary>
        public bool? AllowUnimplementedSyscalls = null; // true;

        /// <summary>
        /// Allow calls to Worker(...) and importScripts(...) to be Trusted Types compatible.
        /// Trusted Types is a Web Platform feature designed to mitigate DOM XSS by restricting
        /// the usage of DOM sink APIs. See https://w3c.github.io/webappsec-trusted-types/.
        /// [link]
        /// </summary>
        public bool? TrustedTypes = null; // false;

        /// <summary>
        /// When targeting older browsers emscripten will sometimes require that
        /// polyfills be included in the output.  If you would prefer to take care of
        /// polyfilling yourself via some other mechanism you can prevent emscripten
        /// from generating these by passing ``-sNO_POLYFILL`` or ``-sPOLYFILL=0``
        /// With default browser targets emscripten does not need any polyfills so this
        /// settings is *only* needed when also explicitly targeting older browsers.
        /// </summary>
        public bool? Polyfill = null; // true;

        /// <summary>
        /// If true, add tracing to core runtime functions.
        /// This setting is enabled by default if any of the following debugging settings
        /// are enabled:
        /// - PTHREADS_DEBUG
        /// - DYLINK_DEBUG
        /// - LIBRARY_DEBUG
        /// - GL_DEBUG
        /// - OPENAL_DEBUG
        /// - EXCEPTION_DEBUG
        /// - SYSCALL_DEBUG
        /// - WEBSOCKET_DEBUG
        /// - SOCKET_DEBUG
        /// - FETCH_DEBUG
        /// [link]
        /// </summary>
        public bool? RuntimeDebug = null; // false;

        /// <summary>
        /// Include JS library symbols that were previously part of the default runtime.
        /// Without this, such symbols can be made available by adding them to
        /// DEFAULT_LIBRARY_FUNCS_TO_INCLUDE, or via the dependencies of another JS
        /// library symbol.
        /// </summary>
        public bool? LegacyRuntime = null; // false;

        /// <summary>
        /// User-defined functions to wrap with signature conversion, which take or return
        /// pointer argument. Only affects MEMORY64=1 builds, see create_pointer_conversion_wrappers
        /// in emscripten.py for details.
        /// Use _ for non-pointer arguments, p for pointer/i53 arguments, and P for optional pointer/i53 values.
        /// Example use -sSIGNATURE_CONVERSIONS=someFunction:_p,anotherFunction:p
        /// [link]
        /// </summary>
        public string[] SignatureConversions = null;



        private string cmd = "";


        public string Create()
        { 
            SetOption("ASSERTIONS",                                         Assertions);
            SetOption("STACK_OVERFLOW_CHECK",                               StackOverflowCheck);
            SetOption("CHECK_NULL_WRITES",                                  CheckNullWrites);
            SetOption("VERBOSE",                                            Verbose);
            SetOption("INVOKE_RUN",                                         InvokeRun);
            SetOption("EXIT_RUNTIME",                                       ExitRuntime);
            SetOption("STACK_SIZE",                                         StackSize);
            SetOption("MALLOC",                                             Malloc);
            SetOption("ABORTING_MALLOC",                                    AbortingMalloc);
            SetOption("INITIAL_MEMORY",                                     InitialMemory);
            SetOption("MAXIMUM_MEMORY",                                     MaximumMemory);
            SetOption("ALLOW_MEMORY_GROWTH",                                AllowMemoryGrowth);
            SetOption("MEMORY_GROWTH_GEOMETRIC_STEP",                       MemoryGrowthGeometricStep);
            SetOption("MEMORY_GROWTH_GEOMETRIC_CAP",                        MemoryGrowthGeometricCap);
            SetOption("MEMORY_GROWTH_LINEAR_STEP",                          MemoryGrowthLinearStep);
            SetOption("MEMORY64",                                           Memory64);
            SetOption("INITIAL_TABLE",                                      InitialTable);
            SetOption("ALLOW_TABLE_GROWTH",                                 AllowTableGrowth);
            SetOption("GLOBAL_BASE",                                        GlobalBase);
            SetOption("TABLE_BASE",                                         TableBase);
            SetOption("USE_CLOSURE_COMPILER",                               UseClosureCompiler);
            SetOption("CLOSURE_WARNINGS",                                   ClosureWarnings);
            SetOption("IGNORE_CLOSURE_COMPILER_ERRORS",                     IgnoreClosureCompilerErrors);
            SetOption("DECLARE_ASM_MODULE_EXPORTS",                         DeclareAsmModuleExports);
            SetOption("INLINING_LIMIT",                                     InliningLimit);
            SetOption("SUPPORT_BIG_ENDIAN",                                 SupportBigEndian);
            SetOption("SAFE_HEAP",                                          SafeHeap);
            SetOption("SAFE_HEAP_LOG",                                      SafeHeapLog);
            SetOption("EMULATE_FUNCTION_POINTER_CASTS",                     EmulateFunctionPointerCasts);
            SetOption("EXCEPTION_DEBUG",                                    ExceptionDebug);
            SetOption("DEMANGLE_SUPPORT",                                   DemangleSupport);
            SetOption("LIBRARY_DEBUG",                                      LibraryDebug);
            SetOption("SYSCALL_DEBUG",                                      SyscallDebug);
            SetOption("SOCKET_DEBUG",                                       SocketDebug);
            SetOption("DYLINK_DEBUG",                                       DylinkDebug);
            SetOption("FS_DEBUG",                                           FsDebug);
            SetOption("SOCKET_WEBRTC",                                      SocketWebrtc);
            SetOption("WEBSOCKET_URL",                                      WebSocketUrl);
            SetOption("PROXY_POSIX_SOCKETS",                                ProxyPosixSockets);
            SetOption("WEBSOCKET_SUBPROTOCOL",                              WebSocketSubprotocol);
            SetOption("OPENAL_DEBUG",                                       OpenALDebug);
            SetOption("WEBSOCKET_DEBUG",                                    WebSocketDebug);
            SetOption("GL_ASSERTIONS",                                      GlAssertions);
            SetOption("TRACE_WEBGL_CALLS",                                  TraceWebglCalls);
            SetOption("GL_DEBUG",                                           GlDebug);
            SetOption("GL_TESTING",                                         GlTesting);
            SetOption("GL_MAX_TEMP_BUFFER_SIZE",                            GlMaxTempBufferSize);
            SetOption("GL_UNSAFE_OPTS",                                     GlUnsafeOpts);
            SetOption("FULL_ES2",                                           FullEs2);
            SetOption("GL_EMULATE_GLES_VERSION_STRING_FORMAT",              GlEmulateGlesVersionStringFormat);
            SetOption("GL_EXTENSIONS_IN_PREFIXED_FORMAT",                   GlExtensionsInPrefixedFormat);
            SetOption("GL_SUPPORT_AUTOMATIC_ENABLE_EXTENSIONS",             GlSupportAutomaticEnableExtensions);
            SetOption("GL_SUPPORT_SIMPLE_ENABLE_EXTENSIONS",                GlSupportSimpleEnableExtensions);
            SetOption("GL_TRACK_ERRORS",                                    GlTrackErrors);
            SetOption("GL_SUPPORT_EXPLICIT_SWAP_CONTROL",                   GlSupportExplicitSwapControl);
            SetOption("GL_POOL_TEMP_BUFFERS",                               GlPoolTempBuffers);
            SetOption("GL_EXPLICIT_UNIFORM_LOCATION",                       GlExplicitUniformLocation);
            SetOption("GL_EXPLICIT_UNIFORM_BINDING",                        GlExplicitUniformBinding);
            SetOption("USE_WEBGL2",                                         UseWebGL2);
            SetOption("MIN_WEBGL_VERSION",                                  MinWebGLVersion);
            SetOption("MAX_WEBGL_VERSION",                                  MaxWebGLVersion);
            SetOption("WEBGL2_BACKWARDS_COMPATIBILITY_EMULATION",           WebGL2BackwardsCompatibilityEmulation);
            SetOption("FULL_ES3",                                           FullEs3);
            SetOption("LEGACY_GL_EMULATION",                                LegacyGLEmulation);
            SetOption("GL_FFP_ONLY",                                        GlFfpOnly);
            SetOption("GL_PREINITIALIZED_CONTEXT",                          GlPreinitializedContext);
            SetOption("USE_WEBGPU",                                         UseWebGPU);
            SetOption("STB_IMAGE",                                          StbImage);
            SetOption("GL_DISABLE_HALF_FLOAT_EXTENSION_IF_BROKEN",          GlDisableHalfFloatExtensionIfBroken);
            SetOption("GL_WORKAROUND_SAFARI_GETCONTEXT_BUG",                GlWorkaroundSafariGetContextBug);
            SetOption("GL_ENABLE_GET_PROC_ADDRESS",                         GlEnableGetProcAddress);
            SetOption("JS_MATH",                                            JsMath);
            SetOption("LEGACY_VM_SUPPORT",                                  LegacyVmSupport);
            SetOption("ENVIRONMENT",                                        Environment);
            SetOption("LZ4",                                                Lz4);
            SetOption("DISABLE_EXCEPTION_CATCHING",                         DisableExceptionCatching);
            SetOption("EXCEPTION_CATCHING_ALLOWED",                         ExceptionCatchingAllowed);
            SetOption("DISABLE_EXCEPTION_THROWING",                         DisableExceptionThrowing);
            SetOption("EXPORT_EXCEPTION_HANDLING_HELPERS",                  ExportExceptionHandlingHelpers);
            SetOption("EXCEPTION_STACK_TRACES",                             ExceptionStackTraces);
            SetOption("NODEJS_CATCH_EXIT",                                  NodeJSCatchExit);
            SetOption("NODEJS_CATCH_REJECTION",                             NodeJSCatchRejection);
            SetOption("ASYNCIFY",                                           Asyncify);
            SetOption("ASYNCIFY_IMPORTS",                                   AsyncifyImports);
            SetOption("ASYNCIFY_IGNORE_INDIRECT",                           AsyncifyIgnoreIndirect);
            SetOption("ASYNCIFY_STACK_SIZE",                                AsyncifyStackSize);
            SetOption("ASYNCIFY_REMOVE",                                    AsyncifyRemove);
            SetOption("ASYNCIFY_ADD",                                       AsyncifyAdd);
            SetOption("ASYNCIFY_ONLY",                                      AsyncifyOnly);
            SetOption("ASYNCIFY_ADVISE",                                    AsyncifyAdvise);
            SetOption("ASYNCIFY_LAZY_LOAD_CODE",                            AsyncifyLazyLoadCode);
            SetOption("ASYNCIFY_DEBUG",                                     AsyncifyDebug);
            SetOption("ASYNCIFY_EXPORTS",                                   AsyncifyExports);
            SetOption("EXPORTED_RUNTIME_METHODS",                           ExportedRuntimeMethods);
            SetOption("INCOMING_MODULE_JS_API",                             IncomingModuleJsApi);
            SetOption("CASE_INSENSITIVE_FS",                                CaseInsensitiveFs);
            SetOption("FILESYSTEM",                                         Filesystem);
            SetOption("FORCE_FILESYSTEM",                                   ForceFilesystem);
            SetOption("NODERAWFS",                                          NodeRawFs);
            SetOption("NODE_CODE_CACHING",                                  NodeCodeCaching);
            SetOption("EXPORTED_FUNCTIONS",                                 ExportedFunctions);
            SetOption("EXPORT_ALL",                                         ExportAll);
            SetOption("EXPORT_KEEPALIVE",                                   ExportKeepAlive);
            SetOption("RETAIN_COMPILER_SETTINGS",                           RetainCompilerSettings);
            SetOption("DEFAULT_LIBRARY_FUNCS_TO_INCLUDE",                   DefaultLibraryFuncsToInclude);
            SetOption("INCLUDE_FULL_LIBRARY",                               IncludeFullLibrary);
            SetOption("RELOCATABLE",                                        Relocatable);
            SetOption("MAIN_MODULE",                                        MainModule);
            SetOption("SIDE_MODULE",                                        SideModule);
            SetOption("RUNTIME_LINKED_LIBS",                                RuntimeLinkedLibs);
            SetOption("BUILD_AS_WORKER",                                    BuildAsWorker);
            SetOption("PROXY_TO_WORKER",                                    ProxyToWorker);
            SetOption("PROXY_TO_WORKER_FILENAME",                           ProxyToWorkerFilename);
            SetOption("PROXY_TO_PTHREAD",                                   ProxyToPthread);
            SetOption("LINKABLE",                                           Linkable);
            SetOption("STRICT",                                             Strict);
            SetOption("IGNORE_MISSING_MAIN",                                IgnoreMissingMain);
            SetOption("STRICT_JS",                                          StrictJs);
            SetOption("WARN_ON_UNDEFINED_SYMBOLS",                          WarnOnUndefinedSymbols);
            SetOption("ERROR_ON_UNDEFINED_SYMBOLS",                         ErrorOnUndefinedSymbols);
            SetOption("SMALL_XHR_CHUNKS",                                   SmallXhrChunks);
            SetOption("HEADLESS",                                           Headless);
            SetOption("DETERMINISTIC",                                      Deterministic);
            SetOption("MODULARIZE",                                         Modularize);
            SetOption("EXPORT_ES6",                                         ExportES6);
            SetOption("USE_ES6_IMPORT_META",                                UseES6ImportMeta);
            SetOption("EXPORT_NAME",                                        ExportName);
            SetOption("DYNAMIC_EXECUTION",                                  DynamicExecution);
            SetOption("BOOTSTRAPPING_STRUCT_INFO",                          BootstrappingStructInfo);
            SetOption("EMSCRIPTEN_TRACING",                                 EmscriptenTracing);
            SetOption("USE_GLFW",                                           UseGLFW);
            SetOption("WASM",                                               WASM);
            SetOption("STANDALONE_WASM",                                    StandaloneWasm);
            SetOption("BINARYEN_IGNORE_IMPLICIT_TRAPS",                     BinaryenIgnoreImplicitTraps);
            SetOption("BINARYEN_EXTRA_PASSES",                              BinaryenExtraPasses);
            SetOption("WASM_ASYNC_COMPILATION",                             WasmAsyncCompilation);
            SetOption("DYNCALLS",                                           DynCalls);
            SetOption("WASM_BIGINT",                                        WasmBigInt);
            SetOption("EMIT_PRODUCERS_SECTION",                             EmitProducersSection);
            SetOption("EMIT_EMSCRIPTEN_LICENSE",                            EmitEmscriptenLicense);
            SetOption("LEGALIZE_JS_FFI",                                    LegalizeJsFfi);
            SetOption("USE_SDL",                                            UseSDL);
            SetOption("USE_SDL_GFX",                                        UseSDLGfx);
            SetOption("USE_SDL_IMAGE",                                      UseSDLImage);
            SetOption("USE_SDL_TTF",                                        UseSDLTtf);
            SetOption("USE_SDL_NET",                                        UseSDLNet);
            SetOption("USE_ICU",                                            UseICU);
            SetOption("USE_ZLIB",                                           UseZlib);
            SetOption("USE_BZIP2",                                          UseBzip2);
            SetOption("USE_GIFLIB",                                         UseGiflib);
            SetOption("USE_LIBJPEG",                                        UseLibjpeg);
            SetOption("USE_LIBPNG",                                         UseLibpng);
            SetOption("USE_REGAL",                                          UseRegal);
            SetOption("USE_BOOST_HEADERS",                                  UseBoostHeaders);
            SetOption("USE_BULLET",                                         UseBullet);
            SetOption("USE_VORBIS",                                         UseVorbis);
            SetOption("USE_OGG",                                            UseOgg);
            SetOption("USE_MPG123",                                         UseMpg123);
            SetOption("USE_FREETYPE",                                       UseFreetype);
            SetOption("USE_SDL_MIXER",                                      UseSdlMixer);
            SetOption("USE_HARFBUZZ",                                       UseHarfbuzz);
            SetOption("USE_COCOS2D",                                        UseCocos2D);
            SetOption("USE_MODPLUG",                                        UseModplug);
            SetOption("SDL2_IMAGE_FORMATS",                                 SDL2ImageFormats);
            SetOption("SDL2_MIXER_FORMATS",                                 SDL2MixerFormats);
            SetOption("USE_SQLITE3",                                        UseSqlite3);
            SetOption("SHARED_MEMORY",                                      SharedMemory);
            SetOption("WASM_WORKERS",                                       WasmWorkers);
            SetOption("AUDIO_WORKLET",                                      AudioWorklet);
            SetOption("WEBAUDIO_DEBUG",                                     WebAudioDebug);
            SetOption("PTHREAD_POOL_SIZE",                                  PthreadPoolSize);
            SetOption("PTHREAD_POOL_SIZE_STRICT",                           PthreadPoolSizeStrict);
            SetOption("PTHREAD_POOL_DELAY_LOAD",                            PthreadPoolDelayLoad);
            SetOption("DEFAULT_PTHREAD_STACK_SIZE",                         DefaultPthreadStackSize);
            SetOption("PTHREADS_PROFILING",                                 PthreadsProfiling);
            SetOption("ALLOW_BLOCKING_ON_MAIN_THREAD",                      AllowBlockingOnMainThread);
            SetOption("PTHREADS_DEBUG",                                     PthreadsDebug);
            SetOption("EVAL_CTORS",                                         EvalCtors);
            SetOption("TEXTDECODER",                                        TextDecoder);
            SetOption("EMBIND_STD_STRING_IS_UTF8",                          EmbindStdStringIsUtf8);
            SetOption("EMBIND_AOT",                                         EmbindAot);
            SetOption("OFFSCREENCANVAS_SUPPORT",                            OffscreenCanvasSupport);
            SetOption("OFFSCREENCANVASES_TO_PTHREAD",                       OffscreenCanvasesToPthread);
            SetOption("OFFSCREEN_FRAMEBUFFER",                              OffscreenFramebuffer);
            SetOption("FETCH_SUPPORT_INDEXEDDB",                            FetchSupportIndexedDB);
            SetOption("FETCH_DEBUG",                                        FetchDebug);
            SetOption("FETCH",                                              Fetch);
            SetOption("WASMFS",                                             Wasmfs);
            SetOption("SINGLE_FILE",                                        SingleFile);
            SetOption("AUTO_JS_LIBRARIES",                                  AutoJsLibraries);
            SetOption("AUTO_NATIVE_LIBRARIES",                              AutoNativeLibraries);
            SetOption("MIN_FIREFOX_VERSION",                                MinFirefoxVersion);
            SetOption("MIN_SAFARI_VERSION",                                 MinSafariVersion);
            SetOption("MIN_CHROME_VERSION",                                 MinChromeVersion);
            SetOption("MIN_NODE_VERSION",                                   MinNodeVersion);
            SetOption("SUPPORT_ERRNO",                                      SupportErrno);
            SetOption("MINIMAL_RUNTIME",                                    MinimalRuntime);
            SetOption("MINIMAL_RUNTIME_STREAMING_WASM_COMPILATION",         MinimalRuntimeStreamingWasmCompilation);
            SetOption("MINIMAL_RUNTIME_STREAMING_WASM_INSTANTIATION",       MinimalRuntimeStreamingWasmInstantiation);
            SetOption("SUPPORT_LONGJMP",                                    SupportLongjmp);
            SetOption("DISABLE_DEPRECATED_FIND_EVENT_TARGET_BEHAVIOR",      DisableDeprecatedFindEventTargetBehavior);
            SetOption("HTML5_SUPPORT_DEFERRING_USER_SENSITIVE_REQUESTS",    Html5SupportDeferringUserSensitiveRequests);
            SetOption("MINIFY_HTML",                                        MinifyHtml);
            SetOption("MAYBE_WASM2JS",                                      MaybeWasm2Js);
            SetOption("ASAN_SHADOW_SIZE",                                   AsanShadowSize);
            SetOption("USE_OFFSET_CONVERTER",                               UseOffsetConverter);
            SetOption("LOAD_SOURCE_MAP",                                    LoadSourceMap);
            SetOption("DEFAULT_TO_CXX",                                     DefaultToCxx);
            SetOption("PRINTF_LONG_DOUBLE",                                 PrintfLongDouble);
            SetOption("SEPARATE_DWARF_URL",                                 SeparateDwarfUrl);
            SetOption("ERROR_ON_WASM_CHANGES_AFTER_LINK",                   ErrorOnWasmChangesAfterLink);
            SetOption("ABORT_ON_WASM_EXCEPTIONS",                           AbortOnWasmExceptions);
            SetOption("PURE_WASI",                                          PureWasi);
            SetOption("IMPORTED_MEMORY",                                    ImportedMemory);
            SetOption("SPLIT_MODULE",                                       SplitModule);
            SetOption("AUTOLOAD_DYLIBS",                                    AutoloadDylibs);
            SetOption("ALLOW_UNIMPLEMENTED_SYSCALLS",                       AllowUnimplementedSyscalls);
            SetOption("TRUSTED_TYPES",                                      TrustedTypes);
            SetOption("POLYFILL",                                           Polyfill);
            SetOption("RUNTIME_DEBUG",                                      RuntimeDebug);
            SetOption("LEGACY_RUNTIME",                                     LegacyRuntime);
            SetOption("SIGNATURE_CONVERSIONS",                              SignatureConversions);

            return cmd.Trim();
        }





        protected void SetOption(string argumentName, bool? value)
        {
            if (value.HasValue)
                cmd += "-s" + argumentName + "=" + (value == true ? 1 : 0) + " ";
        }

        protected void SetOption(string argumentName, int? value)
        {
            if (value.HasValue)
                cmd += "-s" + argumentName + "=" + value + " ";
        }

        protected void SetOption(string argumentName, long? value)
        {
            if (value.HasValue)
                cmd += "-s" + argumentName + "=" + value + " ";
        }

        protected void SetOption(string argumentName, double? value)
        {
            if (value.HasValue)
                cmd += "-s" + argumentName + "=" + value + " ";
        }

        protected void SetOption(string argumentName, string? value)
        {
            if (value != null)
                cmd += "-s" + argumentName + "=\'" + value + "\' ";
        }

        protected void SetOption(string argumentName, string[]? value)
        {
            if (value != null)
                cmd += "-s" + argumentName + "=\'" + string.Join(",", value.Select(s => $"\"{s}\"")) + "\' ";
        }
    }
}
