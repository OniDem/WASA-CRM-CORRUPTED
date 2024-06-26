; ModuleID = 'marshal_methods.arm64-v8a.ll'
source_filename = "marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [370 x ptr] zeroinitializer, align 8

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [740 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 258
	i64 98382396393917666, ; 1: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 211
	i64 120698629574877762, ; 2: Mono.Android => 0x1accec39cafe242 => 171
	i64 131669012237370309, ; 3: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 216
	i64 160518225272466977, ; 4: Microsoft.Extensions.Hosting.Abstractions => 0x23a4679b5576e21 => 201
	i64 196720943101637631, ; 5: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 58
	i64 210515253464952879, ; 6: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 244
	i64 229794953483747371, ; 7: System.ValueTuple.dll => 0x330654aed93802b => 151
	i64 232391251801502327, ; 8: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 286
	i64 233177144301842968, ; 9: Xamarin.AndroidX.Collection.Jvm.dll => 0x33c696097d9f218 => 245
	i64 295915112840604065, ; 10: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 289
	i64 316157742385208084, ; 11: Xamarin.AndroidX.Core.Core.Ktx.dll => 0x46337caa7dc1b14 => 252
	i64 350667413455104241, ; 12: System.ServiceProcess.dll => 0x4ddd227954be8f1 => 132
	i64 354178770117062970, ; 13: Microsoft.Extensions.Options.ConfigurationExtensions.dll => 0x4ea4bb703cff13a => 210
	i64 422779754995088667, ; 14: System.IO.UnmanagedMemoryStream => 0x5de03f27ab57d1b => 56
	i64 435118502366263740, ; 15: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x609d9f8f8bdb9bc => 288
	i64 560278790331054453, ; 16: System.Reflection.Primitives => 0x7c6829760de3975 => 95
	i64 634308326490598313, ; 17: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 271
	i64 648449422406355874, ; 18: Microsoft.Extensions.Configuration.FileExtensions.dll => 0x8ffc15065568ba2 => 189
	i64 649145001856603771, ; 19: System.Security.SecureString => 0x90239f09b62167b => 129
	i64 668723562677762733, ; 20: Microsoft.Extensions.Configuration.Binder.dll => 0x947c88986577aad => 186
	i64 687654259221141486, ; 21: Xamarin.GooglePlayServices.Base => 0x98b09e7c92917ee => 321
	i64 750875890346172408, ; 22: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 145
	i64 798450721097591769, ; 23: Xamarin.AndroidX.Collection.Ktx.dll => 0xb14aab351ad2bd9 => 246
	i64 799765834175365804, ; 24: System.ComponentModel.dll => 0xb1956c9f18442ac => 18
	i64 805302231655005164, ; 25: hu\Microsoft.Maui.Controls.resources.dll => 0xb2d021ceea03bec => 345
	i64 870603111519317375, ; 26: SQLitePCLRaw.lib.e_sqlite3.android => 0xc1500ead2756d7f => 221
	i64 872800313462103108, ; 27: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 257
	i64 895210737996778430, ; 28: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0xc6c6d6c5569cbbe => 272
	i64 939012430102503855, ; 29: Xamarin.AndroidX.Camera.Video => 0xd080ad47fefa1af => 241
	i64 940822596282819491, ; 30: System.Transactions => 0xd0e792aa81923a3 => 150
	i64 960778385402502048, ; 31: System.Runtime.Handles.dll => 0xd555ed9e1ca1ba0 => 104
	i64 1010599046655515943, ; 32: System.Reflection.Primitives.dll => 0xe065e7a82401d27 => 95
	i64 1120440138749646132, ; 33: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 309
	i64 1268860745194512059, ; 34: System.Drawing.dll => 0x119be62002c19ebb => 36
	i64 1301485588176585670, ; 35: SQLitePCLRaw.core => 0x120fce3f338e43c6 => 220
	i64 1301626418029409250, ; 36: System.Diagnostics.FileVersionInfo => 0x12104e54b4e833e2 => 28
	i64 1315114680217950157, ; 37: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 235
	i64 1369545283391376210, ; 38: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 279
	i64 1404195534211153682, ; 39: System.IO.FileSystem.Watcher.dll => 0x137cb4660bd87f12 => 50
	i64 1425944114962822056, ; 40: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 115
	i64 1465843056802068477, ; 41: Xamarin.Firebase.Components.dll => 0x1457b87e6928f7fd => 302
	i64 1476839205573959279, ; 42: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 70
	i64 1486715745332614827, ; 43: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 213
	i64 1491290866305144020, ; 44: Xamarin.Google.AutoValue.Annotations.dll => 0x14b2212446e714d4 => 311
	i64 1492954217099365037, ; 45: System.Net.HttpListener => 0x14b809f350210aad => 65
	i64 1513467482682125403, ; 46: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 170
	i64 1518315023656898250, ; 47: SQLitePCLRaw.provider.e_sqlite3 => 0x151223783a354eca => 222
	i64 1537168428375924959, ; 48: System.Threading.Thread.dll => 0x15551e8a954ae0df => 145
	i64 1576750169145655260, ; 49: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x15e1bdecc376bfdc => 300
	i64 1624659445732251991, ; 50: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 234
	i64 1628611045998245443, ; 51: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 275
	i64 1636321030536304333, ; 52: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 265
	i64 1641285978062550578, ; 53: Xamarin.Google.MLKit.Vision.Interfaces.dll => 0x16c704e6b13f7632 => 320
	i64 1651782184287836205, ; 54: System.Globalization.Calendars => 0x16ec4f2524cb982d => 40
	i64 1659332977923810219, ; 55: System.Reflection.DispatchProxy => 0x1707228d493d63ab => 89
	i64 1672383392659050004, ; 56: Microsoft.Data.Sqlite.dll => 0x17357fd5bfb48e14 => 177
	i64 1682513316613008342, ; 57: System.Net.dll => 0x17597cf276952bd6 => 81
	i64 1735388228521408345, ; 58: System.Net.Mail.dll => 0x181556663c69b759 => 66
	i64 1743969030606105336, ; 59: System.Memory.dll => 0x1833d297e88f2af8 => 62
	i64 1767386781656293639, ; 60: System.Private.Uri.dll => 0x188704e9f5582107 => 86
	i64 1795316252682057001, ; 61: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 233
	i64 1825687700144851180, ; 62: System.Runtime.InteropServices.RuntimeInformation.dll => 0x1956254a55ef08ec => 106
	i64 1835311033149317475, ; 63: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 339
	i64 1836611346387731153, ; 64: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 286
	i64 1837131419302612636, ; 65: Xamarin.Google.Android.DataTransport.TransportBackendCct.dll => 0x197ecd4ad53dce9c => 307
	i64 1854145951182283680, ; 66: System.Runtime.CompilerServices.VisualC => 0x19bb3feb3df2e3a0 => 102
	i64 1875417405349196092, ; 67: System.Drawing.Primitives => 0x1a06d2319b6c713c => 35
	i64 1875917498431009007, ; 68: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 230
	i64 1881198190668717030, ; 69: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 361
	i64 1897575647115118287, ; 70: Xamarin.AndroidX.Security.SecurityCrypto => 0x1a558aff4cba86cf => 288
	i64 1920760634179481754, ; 71: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 214
	i64 1972385128188460614, ; 72: System.Security.Cryptography.Algorithms => 0x1b5f51d2edefbe46 => 119
	i64 1981742497975770890, ; 73: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 273
	i64 2040001226662520565, ; 74: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 142
	i64 2062890601515140263, ; 75: System.Threading.Tasks.Dataflow => 0x1ca0dc1289cd44a7 => 141
	i64 2064708342624596306, ; 76: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x1ca7514c5eecb152 => 328
	i64 2080945842184875448, ; 77: System.IO.MemoryMappedFiles => 0x1ce10137d8416db8 => 53
	i64 2102659300918482391, ; 78: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 35
	i64 2106033277907880740, ; 79: System.Threading.Tasks.Dataflow.dll => 0x1d3a221ba6d9cb24 => 141
	i64 2165252314452558154, ; 80: Xamarin.AndroidX.Camera.Camera2.dll => 0x1e0c85820c09814a => 238
	i64 2165310824878145998, ; 81: Xamarin.Android.Glide.GifDecoder => 0x1e0cbab9112b81ce => 227
	i64 2165725771938924357, ; 82: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 237
	i64 2192948757939169934, ; 83: Microsoft.EntityFrameworkCore.Abstractions.dll => 0x1e6eeb46cf992a8e => 179
	i64 2200176636225660136, ; 84: Microsoft.Extensions.Logging.Debug.dll => 0x1e8898fe5d5824e8 => 206
	i64 2203565783020068373, ; 85: Xamarin.KotlinX.Coroutines.Core => 0x1e94a367981dde15 => 331
	i64 2262844636196693701, ; 86: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 257
	i64 2287834202362508563, ; 87: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 8
	i64 2287887973817120656, ; 88: System.ComponentModel.DataAnnotations.dll => 0x1fc035fd8d41f790 => 14
	i64 2304837677853103545, ; 89: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0x1ffc6da80d5ed5b9 => 285
	i64 2315304989185124968, ; 90: System.IO.FileSystem.dll => 0x20219d9ee311aa68 => 51
	i64 2329709569556905518, ; 91: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 268
	i64 2335503487726329082, ; 92: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 136
	i64 2337758774805907496, ; 93: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 101
	i64 2470498323731680442, ; 94: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 250
	i64 2479423007379663237, ; 95: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 295
	i64 2497223385847772520, ; 96: System.Runtime => 0x22a7eb7046413568 => 116
	i64 2547086958574651984, ; 97: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 228
	i64 2592350477072141967, ; 98: System.Xml.dll => 0x23f9e10627330e8f => 163
	i64 2602673633151553063, ; 99: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 360
	i64 2624866290265602282, ; 100: mscorlib.dll => 0x246d65fbde2db8ea => 166
	i64 2632269733008246987, ; 101: System.Net.NameResolution => 0x2487b36034f808cb => 67
	i64 2656907746661064104, ; 102: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 192
	i64 2662981627730767622, ; 103: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 335
	i64 2706075432581334785, ; 104: System.Net.WebSockets => 0x258de944be6c0701 => 80
	i64 2783046991838674048, ; 105: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 101
	i64 2787234703088983483, ; 106: Xamarin.AndroidX.Startup.StartupRuntime => 0x26ae3f31ef429dbb => 290
	i64 2815524396660695947, ; 107: System.Security.AccessControl => 0x2712c0857f68238b => 117
	i64 2895129759130297543, ; 108: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 340
	i64 2897279701402357900, ; 109: Microsoft.Extensions.Hosting => 0x28353489b909908c => 200
	i64 2923871038697555247, ; 110: Jsr305Binding => 0x2893ad37e69ec52f => 312
	i64 3017136373564924869, ; 111: System.Net.WebProxy => 0x29df058bd93f63c5 => 78
	i64 3017704767998173186, ; 112: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 309
	i64 3106852385031680087, ; 113: System.Runtime.Serialization.Xml => 0x2b1dc1c88b637057 => 114
	i64 3110390492489056344, ; 114: System.Security.Cryptography.Csp.dll => 0x2b2a53ac61900058 => 121
	i64 3135773902340015556, ; 115: System.IO.FileSystem.DriveInfo.dll => 0x2b8481c008eac5c4 => 48
	i64 3143515969535650208, ; 116: Xamarin.Firebase.Encoders => 0x2ba0031e85f0a9a0 => 303
	i64 3168817962471953758, ; 117: Microsoft.Extensions.Hosting.Abstractions.dll => 0x2bf9e725d304955e => 201
	i64 3281594302220646930, ; 118: System.Security.Principal => 0x2d8a90a198ceba12 => 128
	i64 3289520064315143713, ; 119: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 266
	i64 3293991522576715523, ; 120: Microsoft.Extensions.Logging.EventLog => 0x2db69bd664554f03 => 207
	i64 3303437397778967116, ; 121: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 231
	i64 3311221304742556517, ; 122: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 82
	i64 3325875462027654285, ; 123: System.Runtime.Numerics => 0x2e27e21c8958b48d => 110
	i64 3328853167529574890, ; 124: System.Net.Sockets.dll => 0x2e327651a008c1ea => 75
	i64 3344514922410554693, ; 125: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 332
	i64 3396143930648122816, ; 126: Microsoft.Extensions.FileProviders.Abstractions => 0x2f2186e9506155c0 => 197
	i64 3411255996856937470, ; 127: Xamarin.GooglePlayServices.Basement => 0x2f5737416a942bfe => 322
	i64 3429672777697402584, ; 128: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 216
	i64 3437845325506641314, ; 129: System.IO.MemoryMappedFiles.dll => 0x2fb5ae1beb8f7da2 => 53
	i64 3493805808809882663, ; 130: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 292
	i64 3494946837667399002, ; 131: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 184
	i64 3508450208084372758, ; 132: System.Net.Ping => 0x30b084e02d03ad16 => 69
	i64 3522470458906976663, ; 133: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 291
	i64 3523004241079211829, ; 134: Microsoft.Extensions.Caching.Memory.dll => 0x30e439b10bb89735 => 183
	i64 3531994851595924923, ; 135: System.Numerics => 0x31042a9aade235bb => 83
	i64 3551103847008531295, ; 136: System.Private.CoreLib.dll => 0x31480e226177735f => 172
	i64 3567343442040498961, ; 137: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 355
	i64 3571415421602489686, ; 138: System.Runtime.dll => 0x319037675df7e556 => 116
	i64 3638003163729360188, ; 139: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 185
	i64 3647754201059316852, ; 140: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 156
	i64 3655542548057982301, ; 141: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 184
	i64 3659371656528649588, ; 142: Xamarin.Android.Glide.Annotations => 0x32c8b3222885dd74 => 225
	i64 3716579019761409177, ; 143: netstandard.dll => 0x3393f0ed5c8c5c99 => 167
	i64 3727469159507183293, ; 144: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 284
	i64 3772598417116884899, ; 145: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 258
	i64 3869221888984012293, ; 146: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 202
	i64 3869649043256705283, ; 147: System.Diagnostics.Tools => 0x35b3c14d74bf0103 => 32
	i64 3889433610606858880, ; 148: Microsoft.Extensions.FileProviders.Physical.dll => 0x35fa0b4301afd280 => 198
	i64 3890352374528606784, ; 149: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 214
	i64 3919223565570527920, ; 150: System.Security.Cryptography.Encoding => 0x3663e111652bd2b0 => 122
	i64 3933021028458823837, ; 151: Xamarin.GooglePlayServices.MLKit.BarcodeScanning.dll => 0x3694e5c98f6e009d => 323
	i64 3933965368022646939, ; 152: System.Net.Requests => 0x369840a8bfadc09b => 72
	i64 3966267475168208030, ; 153: System.Memory => 0x370b03412596249e => 62
	i64 3988670838080432066, ; 154: WASA-Mobile => 0x375a9afe8dbe67c2 => 0
	i64 4006972109285359177, ; 155: System.Xml.XmlDocument => 0x379b9fe74ed9fe49 => 161
	i64 4009997192427317104, ; 156: System.Runtime.Serialization.Primitives => 0x37a65f335cf1a770 => 113
	i64 4070326265757318011, ; 157: da\Microsoft.Maui.Controls.resources.dll => 0x387cb42c56683b7b => 336
	i64 4073500526318903918, ; 158: System.Private.Xml.dll => 0x3887fb25779ae26e => 88
	i64 4073631083018132676, ; 159: Microsoft.Maui.Controls.Compatibility.dll => 0x388871e311491cc4 => 212
	i64 4120493066591692148, ; 160: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 366
	i64 4148881117810174540, ; 161: System.Runtime.InteropServices.JavaScript.dll => 0x3993c9651a66aa4c => 105
	i64 4154383907710350974, ; 162: System.ComponentModel => 0x39a7562737acb67e => 18
	i64 4167269041631776580, ; 163: System.Threading.ThreadPool => 0x39d51d1d3df1cf44 => 146
	i64 4168469861834746866, ; 164: System.Security.Claims.dll => 0x39d96140fb94ebf2 => 118
	i64 4187479170553454871, ; 165: System.Linq.Expressions => 0x3a1cea1e912fa117 => 58
	i64 4201423742386704971, ; 166: Xamarin.AndroidX.Core.Core.Ktx => 0x3a4e74a233da124b => 252
	i64 4205801962323029395, ; 167: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 17
	i64 4235503420553921860, ; 168: System.IO.IsolatedStorage.dll => 0x3ac787eb9b118544 => 52
	i64 4239882675311405204, ; 169: Xamarin.Firebase.Encoders.JSON => 0x3ad716d44f44e894 => 304
	i64 4247996603072512073, ; 170: Xamarin.GooglePlayServices.Tasks => 0x3af3ea6755340049 => 324
	i64 4254494894858080588, ; 171: Xamarin.Google.MLKit.Vision.Interfaces => 0x3b0b0090caba914c => 320
	i64 4282138915307457788, ; 172: System.Reflection.Emit => 0x3b6d36a7ddc70cfc => 92
	i64 4321865999928413850, ; 173: System.Diagnostics.EventLog.dll => 0x3bfa5a3a8c924e9a => 223
	i64 4335356748765836238, ; 174: Xamarin.Google.Android.DataTransport.TransportBackendCct => 0x3c2a47fe48c7b3ce => 307
	i64 4337444564132831293, ; 175: SQLitePCLRaw.batteries_v2.dll => 0x3c31b2d9ae16203d => 219
	i64 4360412976914417659, ; 176: tr\Microsoft.Maui.Controls.resources.dll => 0x3c834c8002fcc7fb => 361
	i64 4373617458794931033, ; 177: System.IO.Pipes.dll => 0x3cb235e806eb2359 => 55
	i64 4397634830160618470, ; 178: System.Security.SecureString.dll => 0x3d0789940f9be3e6 => 129
	i64 4418670123468915552, ; 179: Microsoft.Extensions.Logging.Console.dll => 0x3d524510f0ff0360 => 205
	i64 4477672992252076438, ; 180: System.Web.HttpUtility.dll => 0x3e23e3dcdb8ba196 => 152
	i64 4484706122338676047, ; 181: System.Globalization.Extensions.dll => 0x3e3ce07510042d4f => 41
	i64 4513320955448359355, ; 182: Microsoft.EntityFrameworkCore.Relational => 0x3ea2897f12d379bb => 180
	i64 4533124835995628778, ; 183: System.Reflection.Emit.dll => 0x3ee8e505540534ea => 92
	i64 4547456257930011283, ; 184: Core.dll => 0x3f1bcf5f858ba293 => 367
	i64 4612482779465751747, ; 185: Microsoft.EntityFrameworkCore.Abstractions => 0x4002d4a662a99cc3 => 179
	i64 4621304523737926849, ; 186: Xamarin.Google.MLKit.Common => 0x40222bfac84e0cc1 => 318
	i64 4636684751163556186, ; 187: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 296
	i64 4672453897036726049, ; 188: System.IO.FileSystem.Watcher => 0x40d7e4104a437f21 => 50
	i64 4702770163853758138, ; 189: Xamarin.Firebase.Components => 0x4143988c34cf0eba => 302
	i64 4716677666592453464, ; 190: System.Xml.XmlSerializer => 0x417501590542f358 => 162
	i64 4725285941539738176, ; 191: Xamarin.AndroidX.Camera.Lifecycle => 0x41939687379f9240 => 240
	i64 4743821336939966868, ; 192: System.ComponentModel.Annotations => 0x41d5705f4239b194 => 13
	i64 4754620528327149104, ; 193: Microsoft.Extensions.Logging.Console => 0x41fbce2df0b84630 => 205
	i64 4759461199762736555, ; 194: Xamarin.AndroidX.Lifecycle.Process.dll => 0x420d00be961cc5ab => 270
	i64 4794310189461587505, ; 195: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 228
	i64 4795410492532947900, ; 196: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 291
	i64 4809057822547766521, ; 197: System.Drawing => 0x42bd349c3145ecf9 => 36
	i64 4814660307502931973, ; 198: System.Net.NameResolution.dll => 0x42d11c0a5ee2a005 => 67
	i64 4853321196694829351, ; 199: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 109
	i64 4871824391508510238, ; 200: nb\Microsoft.Maui.Controls.resources.dll => 0x439c3278d7f2c61e => 351
	i64 4953714692329509532, ; 201: sv\Microsoft.Maui.Controls.resources.dll => 0x44bf21444aef129c => 359
	i64 5004316880885403653, ; 202: Xamarin.Google.MLKit.Vision.Common.dll => 0x4572e7b06caa5005 => 319
	i64 5016978339439457408, ; 203: Xamarin.Google.MLKit.Common.dll => 0x459fe337f81e3480 => 318
	i64 5055365687667823624, ; 204: Xamarin.AndroidX.Activity.Ktx.dll => 0x4628444ef7239408 => 229
	i64 5081566143765835342, ; 205: System.Resources.ResourceManager.dll => 0x4685597c05d06e4e => 99
	i64 5099468265966638712, ; 206: System.Resources.ResourceManager => 0x46c4f35ea8519678 => 99
	i64 5103417709280584325, ; 207: System.Collections.Specialized => 0x46d2fb5e161b6285 => 11
	i64 5129462924058778861, ; 208: Microsoft.Data.Sqlite => 0x472f835a350f5ced => 177
	i64 5182934613077526976, ; 209: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 11
	i64 5205316157927637098, ; 210: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 277
	i64 5244375036463807528, ; 211: System.Diagnostics.Contracts.dll => 0x48c7c34f4d59fc28 => 25
	i64 5262971552273843408, ; 212: System.Security.Principal.dll => 0x4909d4be0c44c4d0 => 128
	i64 5278787618751394462, ; 213: System.Net.WebClient.dll => 0x4942055efc68329e => 76
	i64 5280980186044710147, ; 214: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x4949cf7fd7123d03 => 269
	i64 5290786973231294105, ; 215: System.Runtime.Loader => 0x496ca6b869b72699 => 109
	i64 5376510917114486089, ; 216: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 295
	i64 5408338804355907810, ; 217: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 293
	i64 5423376490970181369, ; 218: System.Runtime.InteropServices.RuntimeInformation => 0x4b43b42f2b7b6ef9 => 106
	i64 5440320908473006344, ; 219: Microsoft.VisualBasic.Core => 0x4b7fe70acda9f908 => 2
	i64 5446034149219586269, ; 220: System.Diagnostics.Debug => 0x4b94333452e150dd => 26
	i64 5451019430259338467, ; 221: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 248
	i64 5455356268247083321, ; 222: Xamarin.Google.MLKit.Vision.Common => 0x4bb5519f4c116939 => 319
	i64 5457765010617926378, ; 223: System.Xml.Serialization => 0x4bbde05c557002ea => 157
	i64 5471532531798518949, ; 224: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 359
	i64 5507995362134886206, ; 225: System.Core.dll => 0x4c705499688c873e => 21
	i64 5522859530602327440, ; 226: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 362
	i64 5527431512186326818, ; 227: System.IO.FileSystem.Primitives.dll => 0x4cb561acbc2a8f22 => 49
	i64 5552873915470424749, ; 228: Microsoft.Extensions.Logging.EventLog.dll => 0x4d0fc567de25aaad => 207
	i64 5570799893513421663, ; 229: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 43
	i64 5573260873512690141, ; 230: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 126
	i64 5574231584441077149, ; 231: Xamarin.AndroidX.Annotation.Jvm => 0x4d5ba617ae5f8d9d => 232
	i64 5591791169662171124, ; 232: System.Linq.Parallel => 0x4d9a087135e137f4 => 59
	i64 5650097808083101034, ; 233: System.Security.Cryptography.Algorithms.dll => 0x4e692e055d01a56a => 119
	i64 5692067934154308417, ; 234: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 298
	i64 5724799082821825042, ; 235: Xamarin.AndroidX.ExifInterface => 0x4f72926f3e13b212 => 261
	i64 5757522595884336624, ; 236: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 247
	i64 5783556987928984683, ; 237: Microsoft.VisualBasic => 0x504352701bbc3c6b => 3
	i64 5896680224035167651, ; 238: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 267
	i64 5959344983920014087, ; 239: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x52b3d8b05c8ef307 => 287
	i64 5979151488806146654, ; 240: System.Formats.Asn1 => 0x52fa3699a489d25e => 38
	i64 5984759512290286505, ; 241: System.Security.Cryptography.Primitives => 0x530e23115c33dba9 => 124
	i64 6010974535988770325, ; 242: Microsoft.Extensions.Diagnostics.dll => 0x536b457e33877615 => 195
	i64 6102788177522843259, ; 243: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0x54b1758374b3de7b => 287
	i64 6175278734029192665, ; 244: Microsoft.Extensions.Configuration.CommandLine => 0x55b2ff4a62d57dd9 => 187
	i64 6183170893902868313, ; 245: SQLitePCLRaw.batteries_v2 => 0x55cf092b0c9d6f59 => 219
	i64 6200764641006662125, ; 246: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 356
	i64 6222399776351216807, ; 247: System.Text.Json.dll => 0x565a67a0ffe264a7 => 137
	i64 6251069312384999852, ; 248: System.Transactions.Local => 0x56c0426b870da1ac => 149
	i64 6278736998281604212, ; 249: System.Private.DataContractSerialization => 0x57228e08a4ad6c74 => 85
	i64 6284145129771520194, ; 250: System.Reflection.Emit.ILGeneration => 0x5735c4b3610850c2 => 90
	i64 6300676701234028427, ; 251: es\Microsoft.Maui.Controls.resources.dll => 0x57708013cda25f8b => 339
	i64 6319713645133255417, ; 252: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 271
	i64 6357457916754632952, ; 253: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 369
	i64 6401687960814735282, ; 254: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 268
	i64 6471714727257221498, ; 255: fi\Microsoft.Maui.Controls.resources.dll => 0x59d026417dd4a97a => 340
	i64 6478287442656530074, ; 256: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 344
	i64 6504860066809920875, ; 257: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 237
	i64 6548213210057960872, ; 258: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 254
	i64 6557084851308642443, ; 259: Xamarin.AndroidX.Window.dll => 0x5aff71ee6c58c08b => 299
	i64 6560151584539558821, ; 260: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 209
	i64 6589202984700901502, ; 261: Xamarin.Google.ErrorProne.Annotations.dll => 0x5b718d34180a787e => 314
	i64 6591971792923354531, ; 262: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x5b7b636b7e9765a3 => 269
	i64 6617685658146568858, ; 263: System.Text.Encoding.CodePages => 0x5bd6be0b4905fa9a => 133
	i64 6713440830605852118, ; 264: System.Reflection.TypeExtensions.dll => 0x5d2aeeddb8dd7dd6 => 96
	i64 6739853162153639747, ; 265: Microsoft.VisualBasic.dll => 0x5d88c4bde075ff43 => 3
	i64 6743165466166707109, ; 266: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 352
	i64 6772837112740759457, ; 267: System.Runtime.InteropServices.JavaScript => 0x5dfdf378527ec7a1 => 105
	i64 6786606130239981554, ; 268: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 33
	i64 6798329586179154312, ; 269: System.Windows => 0x5e5884bd523ca188 => 154
	i64 6814185388980153342, ; 270: System.Xml.XDocument.dll => 0x5e90d98217d1abfe => 158
	i64 6876862101832370452, ; 271: System.Xml.Linq => 0x5f6f85a57d108914 => 155
	i64 6878582369430612696, ; 272: Xamarin.Google.Android.DataTransport.TransportRuntime.dll => 0x5f75a238802d2ad8 => 308
	i64 6894844156784520562, ; 273: System.Numerics.Vectors => 0x5faf683aead1ad72 => 82
	i64 6975328107116786489, ; 274: Xamarin.Firebase.Annotations => 0x60cd57f4e07e7339 => 301
	i64 7011053663211085209, ; 275: Xamarin.AndroidX.Fragment.Ktx => 0x614c442918e5dd99 => 263
	i64 7026573318513401069, ; 276: Xamarin.Firebase.Encoders.Proto.dll => 0x618367346e3a9ced => 305
	i64 7060896174307865760, ; 277: System.Threading.Tasks.Parallel.dll => 0x61fd57a90988f4a0 => 143
	i64 7083547580668757502, ; 278: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 87
	i64 7101497697220435230, ; 279: System.Configuration => 0x628d9687c0141d1e => 19
	i64 7103753931438454322, ; 280: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 264
	i64 7112547816752919026, ; 281: System.IO.FileSystem => 0x62b4d88e3189b1f2 => 51
	i64 7192745174564810625, ; 282: Xamarin.Android.Glide.GifDecoder.dll => 0x63d1c3a0a1d72f81 => 227
	i64 7270811800166795866, ; 283: System.Linq => 0x64e71ccf51a90a5a => 61
	i64 7299370801165188114, ; 284: System.IO.Pipes.AccessControl.dll => 0x654c9311e74f3c12 => 54
	i64 7316205155833392065, ; 285: Microsoft.Win32.Primitives => 0x658861d38954abc1 => 4
	i64 7338192458477945005, ; 286: System.Reflection => 0x65d67f295d0740ad => 97
	i64 7349431895026339542, ; 287: Xamarin.Android.Glide.DiskLruCache => 0x65fe6d5e9bf88ed6 => 226
	i64 7377312882064240630, ; 288: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 17
	i64 7476537270401454554, ; 289: Xamarin.Firebase.Encoders.JSON.dll => 0x67c1ff08f83f51da => 304
	i64 7488575175965059935, ; 290: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 155
	i64 7489048572193775167, ; 291: System.ObjectModel => 0x67ee71ff6b419e3f => 84
	i64 7592577537120840276, ; 292: System.Diagnostics.Process => 0x695e410af5b2aa54 => 29
	i64 7637303409920963731, ; 293: System.IO.Compression.ZipFile.dll => 0x69fd26fcb637f493 => 45
	i64 7654504624184590948, ; 294: System.Net.Http => 0x6a3a4366801b8264 => 64
	i64 7694700312542370399, ; 295: System.Net.Mail => 0x6ac9112a7e2cda5f => 66
	i64 7714652370974252055, ; 296: System.Private.CoreLib => 0x6b0ff375198b9c17 => 172
	i64 7725404731275645577, ; 297: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x6b3626ac11ce9289 => 272
	i64 7735176074855944702, ; 298: Microsoft.CSharp => 0x6b58dda848e391fe => 1
	i64 7735352534559001595, ; 299: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 327
	i64 7742555799473854801, ; 300: it\Microsoft.Maui.Controls.resources.dll => 0x6b73157a51479951 => 347
	i64 7756332380610150586, ; 301: Xamarin.Google.AutoValue.Annotations => 0x6ba407349220c0ba => 311
	i64 7791074099216502080, ; 302: System.IO.FileSystem.AccessControl.dll => 0x6c1f749d468bcd40 => 47
	i64 7820441508502274321, ; 303: System.Data => 0x6c87ca1e14ff8111 => 24
	i64 7836164640616011524, ; 304: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 234
	i64 7919757340696389605, ; 305: Microsoft.Extensions.Diagnostics.Abstractions => 0x6de8a157378027e5 => 196
	i64 7969868205614615900, ; 306: Microsoft.Extensions.Logging.Configuration => 0x6e9aa8e82656cd5c => 204
	i64 7972383140441761405, ; 307: Microsoft.Extensions.Caching.Abstractions.dll => 0x6ea3983a0b58267d => 182
	i64 7975724199463739455, ; 308: sk\Microsoft.Maui.Controls.resources.dll => 0x6eaf76e6f785e03f => 358
	i64 8025517457475554965, ; 309: WindowsBase => 0x6f605d9b4786ce95 => 165
	i64 8031450141206250471, ; 310: System.Runtime.Intrinsics.dll => 0x6f757159d9dc03e7 => 108
	i64 8038446328132759779, ; 311: Microsoft.Extensions.Logging.Configuration.dll => 0x6f8e4c588e6570e3 => 204
	i64 8064050204834738623, ; 312: System.Collections.dll => 0x6fe942efa61731bf => 12
	i64 8083354569033831015, ; 313: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 266
	i64 8085230611270010360, ; 314: System.Net.Http.Json.dll => 0x703482674fdd05f8 => 63
	i64 8087206902342787202, ; 315: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 27
	i64 8103644804370223335, ; 316: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 23
	i64 8108129031893776750, ; 317: ko\Microsoft.Maui.Controls.resources.dll => 0x7085dc65530f796e => 349
	i64 8113615946733131500, ; 318: System.Reflection.Extensions => 0x70995ab73cf916ec => 93
	i64 8167236081217502503, ; 319: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 168
	i64 8185542183669246576, ; 320: System.Collections => 0x7198e33f4794aa70 => 12
	i64 8187640529827139739, ; 321: Xamarin.KotlinX.Coroutines.Android => 0x71a057ae90f0109b => 330
	i64 8246048515196606205, ; 322: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 217
	i64 8264926008854159966, ; 323: System.Diagnostics.Process.dll => 0x72b2ea6a64a3a25e => 29
	i64 8290740647658429042, ; 324: System.Runtime.Extensions => 0x730ea0b15c929a72 => 103
	i64 8318905602908530212, ; 325: System.ComponentModel.DataAnnotations => 0x7372b092055ea624 => 14
	i64 8320777595162576093, ; 326: Xamarin.AndroidX.Camera.View => 0x737957232eb1c4dd => 242
	i64 8368701292315763008, ; 327: System.Security.Cryptography => 0x7423997c6fd56140 => 126
	i64 8386351099740279196, ; 328: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x74624de475b9d19c => 364
	i64 8398329775253868912, ; 329: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 249
	i64 8400357532724379117, ; 330: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 281
	i64 8410671156615598628, ; 331: System.Reflection.Emit.Lightweight.dll => 0x74b8b4daf4b25224 => 91
	i64 8426919725312979251, ; 332: Xamarin.AndroidX.Lifecycle.Process => 0x74f26ed7aa033133 => 270
	i64 8472685364375177308, ; 333: Microsoft.Extensions.Configuration.CommandLine.dll => 0x75950672dd3bc85c => 187
	i64 8518412311883997971, ; 334: System.Collections.Immutable => 0x76377add7c28e313 => 9
	i64 8563666267364444763, ; 335: System.Private.Uri => 0x76d841191140ca5b => 86
	i64 8598790081731763592, ; 336: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x77550a055fc61d88 => 260
	i64 8599632406834268464, ; 337: CommunityToolkit.Maui => 0x7758081c784b4930 => 174
	i64 8601935802264776013, ; 338: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 293
	i64 8623059219396073920, ; 339: System.Net.Quic.dll => 0x77ab42ac514299c0 => 71
	i64 8626175481042262068, ; 340: Java.Interop => 0x77b654e585b55834 => 168
	i64 8629545377263870989, ; 341: Xamarin.AndroidX.Camera.Core.dll => 0x77c24dcca0ed640d => 239
	i64 8638972117149407195, ; 342: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 1
	i64 8639588376636138208, ; 343: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 280
	i64 8648495978913578441, ; 344: Microsoft.Win32.Registry.dll => 0x7805a1456889bdc9 => 5
	i64 8677882282824630478, ; 345: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 354
	i64 8684531736582871431, ; 346: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 44
	i64 8695364240710937812, ; 347: Microsoft.Extensions.Logging.EventSource.dll => 0x78ac23b4f835acd4 => 208
	i64 8725526185868997716, ; 348: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 27
	i64 8816904670177563593, ; 349: Microsoft.Extensions.Diagnostics => 0x7a5bf015646a93c9 => 195
	i64 8941376889969657626, ; 350: System.Xml.XDocument => 0x7c1626e87187471a => 158
	i64 8951477988056063522, ; 351: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0x7c3a09cd9ccf5e22 => 283
	i64 8954753533646919997, ; 352: System.Runtime.Serialization.Json => 0x7c45ace50032d93d => 112
	i64 9031035476476434958, ; 353: Xamarin.KotlinX.Coroutines.Core.dll => 0x7d54aeead9541a0e => 331
	i64 9045785047181495996, ; 354: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 364
	i64 9111603110219107042, ; 355: Microsoft.Extensions.Caching.Memory => 0x7e72eac0def44ae2 => 183
	i64 9131857290992441898, ; 356: Xamarin.AndroidX.Camera.Core => 0x7ebadfd2d12a5a2a => 239
	i64 9138683372487561558, ; 357: System.Security.Cryptography.Csp => 0x7ed3201bc3e3d156 => 121
	i64 9250544137016314866, ; 358: Microsoft.EntityFrameworkCore => 0x806088e191ee0bf2 => 178
	i64 9312692141327339315, ; 359: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 298
	i64 9324707631942237306, ; 360: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 233
	i64 9363564275759486853, ; 361: el\Microsoft.Maui.Controls.resources.dll => 0x81f21019382e9785 => 338
	i64 9468215723722196442, ; 362: System.Xml.XPath.XDocument.dll => 0x8365dc09353ac5da => 159
	i64 9551379474083066910, ; 363: uk\Microsoft.Maui.Controls.resources.dll => 0x848d5106bbadb41e => 362
	i64 9554839972845591462, ; 364: System.ServiceModel.Web => 0x84999c54e32a1ba6 => 131
	i64 9575902398040817096, ; 365: Xamarin.Google.Crypto.Tink.Android.dll => 0x84e4707ee708bdc8 => 313
	i64 9584643793929893533, ; 366: System.IO.dll => 0x85037ebfbbd7f69d => 57
	i64 9632653874019266178, ; 367: Xamarin.Google.MLKit.BarcodeScanning.Common => 0x85ae0fa995356e82 => 317
	i64 9650158550865574924, ; 368: Microsoft.Extensions.Configuration.Json => 0x85ec4012c28a7c0c => 190
	i64 9659729154652888475, ; 369: System.Text.RegularExpressions => 0x860e407c9991dd9b => 138
	i64 9662334977499516867, ; 370: System.Numerics.dll => 0x8617827802b0cfc3 => 83
	i64 9667360217193089419, ; 371: System.Diagnostics.StackTrace => 0x86295ce5cd89898b => 30
	i64 9678050649315576968, ; 372: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 250
	i64 9702891218465930390, ; 373: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 10
	i64 9735414641753518179, ; 374: Xamarin.Firebase.Encoders.Proto => 0x871b240946daf063 => 305
	i64 9773637193738963987, ; 375: ca\Microsoft.Maui.Controls.resources.dll => 0x87a2ef3ea85b4c13 => 334
	i64 9780093022148426479, ; 376: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x87b9dec9576efaef => 300
	i64 9808709177481450983, ; 377: Mono.Android.dll => 0x881f890734e555e7 => 171
	i64 9825649861376906464, ; 378: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 247
	i64 9834056768316610435, ; 379: System.Transactions.dll => 0x8879968718899783 => 150
	i64 9836529246295212050, ; 380: System.Reflection.Metadata => 0x88825f3bbc2ac012 => 94
	i64 9864956466380592553, ; 381: Microsoft.EntityFrameworkCore.Sqlite => 0x88e75da3af4ed5a9 => 181
	i64 9875200773399460291, ; 382: Xamarin.GooglePlayServices.Base.dll => 0x890bc2c8482339c3 => 321
	i64 9882471655841731456, ; 383: Xamarin.Google.MLKit.BarcodeScanning => 0x8925979c85501380 => 316
	i64 9907349773706910547, ; 384: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x897dfa20b758db53 => 260
	i64 9933555792566666578, ; 385: System.Linq.Queryable.dll => 0x89db145cf475c552 => 60
	i64 9956195530459977388, ; 386: Microsoft.Maui => 0x8a2b8315b36616ac => 215
	i64 9974604633896246661, ; 387: System.Xml.Serialization.dll => 0x8a6cea111a59dd85 => 157
	i64 10017511394021241210, ; 388: Microsoft.Extensions.Logging.Debug => 0x8b055989ae10717a => 206
	i64 10038780035334861115, ; 389: System.Net.Http.dll => 0x8b50e941206af13b => 64
	i64 10051358222726253779, ; 390: System.Private.Xml => 0x8b7d990c97ccccd3 => 88
	i64 10078727084704864206, ; 391: System.Net.WebSockets.Client => 0x8bded4e257f117ce => 79
	i64 10089571585547156312, ; 392: System.IO.FileSystem.AccessControl => 0x8c055be67469bb58 => 47
	i64 10092835686693276772, ; 393: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 213
	i64 10105485790837105934, ; 394: System.Threading.Tasks.Parallel => 0x8c3de5c91d9a650e => 143
	i64 10143853363526200146, ; 395: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 336
	i64 10171692371253079229, ; 396: WASA-Mobile.dll => 0x8d291c51d9172cbd => 0
	i64 10205853378024263619, ; 397: Microsoft.Extensions.Configuration.Binder => 0x8da279930adb4fc3 => 186
	i64 10209869394718195525, ; 398: nl\Microsoft.Maui.Controls.resources.dll => 0x8db0be1ecb4f7f45 => 352
	i64 10226222362177979215, ; 399: Xamarin.Kotlin.StdLib.Jdk7 => 0x8dead70ebbc6434f => 328
	i64 10229024438826829339, ; 400: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 254
	i64 10236703004850800690, ; 401: System.Net.ServicePoint.dll => 0x8e101325834e4832 => 74
	i64 10245369515835430794, ; 402: System.Reflection.Emit.Lightweight => 0x8e2edd4ad7fc978a => 91
	i64 10321854143672141184, ; 403: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 326
	i64 10360651442923773544, ; 404: System.Text.Encoding => 0x8fc86d98211c1e68 => 135
	i64 10364469296367737616, ; 405: System.Reflection.Emit.ILGeneration.dll => 0x8fd5fde967711b10 => 90
	i64 10376576884623852283, ; 406: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 292
	i64 10406448008575299332, ; 407: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 332
	i64 10430153318873392755, ; 408: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 251
	i64 10506226065143327199, ; 409: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 334
	i64 10546663366131771576, ; 410: System.Runtime.Serialization.Json.dll => 0x925d4673efe8e8b8 => 112
	i64 10566960649245365243, ; 411: System.Globalization.dll => 0x92a562b96dcd13fb => 42
	i64 10595762989148858956, ; 412: System.Xml.XPath.XDocument => 0x930bb64cc472ea4c => 159
	i64 10670374202010151210, ; 413: Microsoft.Win32.Primitives.dll => 0x9414c8cd7b4ea92a => 4
	i64 10714184849103829812, ; 414: System.Runtime.Extensions.dll => 0x94b06e5aa4b4bb34 => 103
	i64 10761706286639228993, ; 415: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0x955942d988382841 => 366
	i64 10785150219063592792, ; 416: System.Net.Primitives => 0x95ac8cfb68830758 => 70
	i64 10809043855025277762, ; 417: Microsoft.Extensions.Options.ConfigurationExtensions => 0x9601701e0c668b42 => 210
	i64 10811915265162633087, ; 418: Microsoft.EntityFrameworkCore.Relational.dll => 0x960ba3a651a45f7f => 180
	i64 10822644899632537592, ; 419: System.Linq.Queryable => 0x9631c23204ca5ff8 => 60
	i64 10830817578243619689, ; 420: System.Formats.Tar => 0x964ecb340a447b69 => 39
	i64 10847732767863316357, ; 421: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 235
	i64 10880838204485145808, ; 422: CommunityToolkit.Maui.dll => 0x970080b2a4d614d0 => 174
	i64 10899834349646441345, ; 423: System.Web => 0x9743fd975946eb81 => 153
	i64 10943875058216066601, ; 424: System.IO.UnmanagedMemoryStream.dll => 0x97e07461df39de29 => 56
	i64 10964653383833615866, ; 425: System.Diagnostics.Tracing => 0x982a4628ccaffdfa => 34
	i64 11002576679268595294, ; 426: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 203
	i64 11004867042320771561, ; 427: Microsoft.Extensions.Logging.EventSource => 0x98b92444c9eee9e9 => 208
	i64 11009005086950030778, ; 428: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 215
	i64 11019817191295005410, ; 429: Xamarin.AndroidX.Annotation.Jvm.dll => 0x98ee415998e1b2e2 => 232
	i64 11023048688141570732, ; 430: System.Core => 0x98f9bc61168392ac => 21
	i64 11037814507248023548, ; 431: System.Xml => 0x992e31d0412bf7fc => 163
	i64 11071824625609515081, ; 432: Xamarin.Google.ErrorProne.Annotations => 0x99a705d600e0a049 => 314
	i64 11103970607964515343, ; 433: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 345
	i64 11136029745144976707, ; 434: Jsr305Binding.dll => 0x9a8b200d4f8cd543 => 312
	i64 11156122287428000958, ; 435: th\Microsoft.Maui.Controls.resources.dll => 0x9ad2821cdcf6dcbe => 360
	i64 11157797727133427779, ; 436: fr\Microsoft.Maui.Controls.resources.dll => 0x9ad875ea9172e843 => 341
	i64 11162124722117608902, ; 437: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 297
	i64 11188319605227840848, ; 438: System.Threading.Overlapped => 0x9b44e5671724e550 => 140
	i64 11220793807500858938, ; 439: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 348
	i64 11226290749488709958, ; 440: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 209
	i64 11235648312900863002, ; 441: System.Reflection.DispatchProxy.dll => 0x9bed0a9c8fac441a => 89
	i64 11299661109949763898, ; 442: Xamarin.AndroidX.Collection.Jvm => 0x9cd075e94cda113a => 245
	i64 11329751333533450475, ; 443: System.Threading.Timer.dll => 0x9d3b5ccf6cc500eb => 147
	i64 11340910727871153756, ; 444: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 253
	i64 11347436699239206956, ; 445: System.Xml.XmlSerializer.dll => 0x9d7a318e8162502c => 162
	i64 11376351552967644903, ; 446: Xamarin.Firebase.Annotations.dll => 0x9de0eb76829996e7 => 301
	i64 11392833485892708388, ; 447: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 282
	i64 11398376662953476300, ; 448: Microsoft.EntityFrameworkCore.Sqlite.dll => 0x9e2f2b2f0b71c0cc => 181
	i64 11432101114902388181, ; 449: System.AppContext => 0x9ea6fb64e61a9dd5 => 6
	i64 11446671985764974897, ; 450: Mono.Android.Export => 0x9edabf8623efc131 => 169
	i64 11448276831755070604, ; 451: System.Diagnostics.TextWriterTraceListener => 0x9ee0731f77186c8c => 31
	i64 11485890710487134646, ; 452: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 107
	i64 11508496261504176197, ; 453: Xamarin.AndroidX.Fragment.Ktx.dll => 0x9fb664600dde1045 => 263
	i64 11518296021396496455, ; 454: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 346
	i64 11529969570048099689, ; 455: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 297
	i64 11530571088791430846, ; 456: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 202
	i64 11580057168383206117, ; 457: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 230
	i64 11591352189662810718, ; 458: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0xa0dcc167234c525e => 290
	i64 11597940890313164233, ; 459: netstandard => 0xa0f429ca8d1805c9 => 167
	i64 11672361001936329215, ; 460: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 264
	i64 11692977985522001935, ; 461: System.Threading.Overlapped.dll => 0xa245cd869980680f => 140
	i64 11707554492040141440, ; 462: System.Linq.Parallel.dll => 0xa27996c7fe94da80 => 59
	i64 11739066727115742305, ; 463: SQLite-net.dll => 0xa2e98afdf8575c61 => 218
	i64 11743665907891708234, ; 464: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 144
	i64 11806260347154423189, ; 465: SQLite-net => 0xa3d8433bc5eb5d95 => 218
	i64 11855031688536399763, ; 466: vi\Microsoft.Maui.Controls.resources.dll => 0xa485888294361f93 => 363
	i64 11913092294968872355, ; 467: Xamarin.Google.Android.ODML.Image.dll => 0xa553ce52f2100da3 => 310
	i64 11991047634523762324, ; 468: System.Net => 0xa668c24ad493ae94 => 81
	i64 12040886584167504988, ; 469: System.Net.ServicePoint => 0xa719d28d8e121c5c => 74
	i64 12048689113179125827, ; 470: Microsoft.Extensions.FileProviders.Physical => 0xa7358ae968287843 => 198
	i64 12058074296353848905, ; 471: Microsoft.Extensions.FileSystemGlobbing.dll => 0xa756e2afa5707e49 => 199
	i64 12063623837170009990, ; 472: System.Security => 0xa76a99f6ce740786 => 130
	i64 12096697103934194533, ; 473: System.Diagnostics.Contracts => 0xa7e019eccb7e8365 => 25
	i64 12102847907131387746, ; 474: System.Buffers => 0xa7f5f40c43256f62 => 7
	i64 12123043025855404482, ; 475: System.Reflection.Extensions.dll => 0xa83db366c0e359c2 => 93
	i64 12137774235383566651, ; 476: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 294
	i64 12145679461940342714, ; 477: System.Text.Json => 0xa88e1f1ebcb62fba => 137
	i64 12191646537372739477, ; 478: Xamarin.Android.Glide.dll => 0xa9316dee7f392795 => 224
	i64 12201331334810686224, ; 479: System.Runtime.Serialization.Primitives.dll => 0xa953d6341e3bd310 => 113
	i64 12269460666702402136, ; 480: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 9
	i64 12279246230491828964, ; 481: SQLitePCLRaw.provider.e_sqlite3.dll => 0xaa68a5636e0512e4 => 222
	i64 12332222936682028543, ; 482: System.Runtime.Handles => 0xab24db6c07db5dff => 104
	i64 12341818387765915815, ; 483: CommunityToolkit.Maui.Core.dll => 0xab46f26f152bf0a7 => 175
	i64 12346958216201575315, ; 484: Xamarin.JavaX.Inject.dll => 0xab593514a5491b93 => 325
	i64 12375446203996702057, ; 485: System.Configuration.dll => 0xabbe6ac12e2e0569 => 19
	i64 12451044538927396471, ; 486: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 262
	i64 12466513435562512481, ; 487: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 276
	i64 12475113361194491050, ; 488: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 369
	i64 12487638416075308985, ; 489: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 256
	i64 12517810545449516888, ; 490: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 33
	i64 12538491095302438457, ; 491: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 243
	i64 12550732019250633519, ; 492: System.IO.Compression => 0xae2d28465e8e1b2f => 46
	i64 12699999919562409296, ; 493: System.Diagnostics.StackTrace.dll => 0xb03f76a3ad01c550 => 30
	i64 12700543734426720211, ; 494: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 244
	i64 12708238894395270091, ; 495: System.IO => 0xb05cbbf17d3ba3cb => 57
	i64 12708922737231849740, ; 496: System.Text.Encoding.Extensions => 0xb05f29e50e96e90c => 134
	i64 12717050818822477433, ; 497: System.Runtime.Serialization.Xml.dll => 0xb07c0a5786811679 => 114
	i64 12753841065332862057, ; 498: Xamarin.AndroidX.Window => 0xb0febee04cf46c69 => 299
	i64 12760970142902902754, ; 499: Xamarin.AndroidX.Camera.Lifecycle.dll => 0xb11812bc0517dfe2 => 240
	i64 12766160108898714747, ; 500: DTO.dll => 0xb12a82fb24ab847b => 368
	i64 12774985883365324828, ; 501: Xamarin.GooglePlayServices.MLKit.BarcodeScanning => 0xb149ddf9e49eb81c => 323
	i64 12828192437253469131, ; 502: Xamarin.Kotlin.StdLib.Jdk8.dll => 0xb206e50e14d873cb => 329
	i64 12835242264250840079, ; 503: System.IO.Pipes => 0xb21ff0d5d6c0740f => 55
	i64 12843321153144804894, ; 504: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 211
	i64 12843770487262409629, ; 505: System.AppContext.dll => 0xb23e3d357debf39d => 6
	i64 12854524964145442905, ; 506: Xamarin.Firebase.Encoders.dll => 0xb26472594447b059 => 303
	i64 12859557719246324186, ; 507: System.Net.WebHeaderCollection.dll => 0xb276539ce04f41da => 77
	i64 12863504542219434948, ; 508: Xamarin.Google.MLKit.BarcodeScanning.dll => 0xb284593a359cfbc4 => 316
	i64 12982280885948128408, ; 509: Xamarin.AndroidX.CustomView.PoolingContainer => 0xb42a53aec5481c98 => 255
	i64 12989346753972519995, ; 510: ar\Microsoft.Maui.Controls.resources.dll => 0xb4436e0d5ee7c43b => 333
	i64 13005833372463390146, ; 511: pt-BR\Microsoft.Maui.Controls.resources.dll => 0xb47e008b5d99ddc2 => 354
	i64 13068258254871114833, ; 512: System.Runtime.Serialization.Formatters.dll => 0xb55bc7a4eaa8b451 => 111
	i64 13129914918964716986, ; 513: Xamarin.AndroidX.Emoji2.dll => 0xb636d40db3fe65ba => 259
	i64 13173818576982874404, ; 514: System.Runtime.CompilerServices.VisualC.dll => 0xb6d2ce32a8819924 => 102
	i64 13343850469010654401, ; 515: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 170
	i64 13370592475155966277, ; 516: System.Runtime.Serialization => 0xb98de304062ea945 => 115
	i64 13381594904270902445, ; 517: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 342
	i64 13401370062847626945, ; 518: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 294
	i64 13404347523447273790, ; 519: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 249
	i64 13431476299110033919, ; 520: System.Net.WebClient => 0xba663087f18829ff => 76
	i64 13454009404024712428, ; 521: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 315
	i64 13463706743370286408, ; 522: System.Private.DataContractSerialization.dll => 0xbad8b1f3069e0548 => 85
	i64 13465488254036897740, ; 523: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 327
	i64 13491513212026656886, ; 524: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 236
	i64 13540124433173649601, ; 525: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 363
	i64 13550417756503177631, ; 526: Microsoft.Extensions.FileProviders.Abstractions.dll => 0xbc0cc1280684799f => 197
	i64 13572454107664307259, ; 527: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 284
	i64 13578472628727169633, ; 528: System.Xml.XPath => 0xbc706ce9fba5c261 => 160
	i64 13580399111273692417, ; 529: Microsoft.VisualBasic.Core.dll => 0xbc77450a277fbd01 => 2
	i64 13621154251410165619, ; 530: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0xbd080f9faa1acf73 => 255
	i64 13647894001087880694, ; 531: System.Data.dll => 0xbd670f48cb071df6 => 24
	i64 13675589307506966157, ; 532: Xamarin.AndroidX.Activity.Ktx => 0xbdc97404d0153e8d => 229
	i64 13702626353344114072, ; 533: System.Diagnostics.Tools.dll => 0xbe29821198fb6d98 => 32
	i64 13710614125866346983, ; 534: System.Security.AccessControl.dll => 0xbe45e2e7d0b769e7 => 117
	i64 13713329104121190199, ; 535: System.Dynamic.Runtime => 0xbe4f8829f32b5737 => 37
	i64 13717397318615465333, ; 536: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 16
	i64 13768883594457632599, ; 537: System.IO.IsolatedStorage => 0xbf14e6adb159cf57 => 52
	i64 13881769479078963060, ; 538: System.Console.dll => 0xc0a5f3cade5c6774 => 20
	i64 13911222732217019342, ; 539: System.Security.Cryptography.OpenSsl.dll => 0xc10e975ec1226bce => 123
	i64 13928444506500929300, ; 540: System.Windows.dll => 0xc14bc67b8bba9714 => 154
	i64 13955418299340266673, ; 541: Microsoft.Extensions.DependencyModel.dll => 0xc1ab9b0118299cb1 => 194
	i64 13959074834287824816, ; 542: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 262
	i64 14075334701871371868, ; 543: System.ServiceModel.Web.dll => 0xc355a25647c5965c => 131
	i64 14124974489674258913, ; 544: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 243
	i64 14125464355221830302, ; 545: System.Threading.dll => 0xc407bafdbc707a9e => 148
	i64 14133832980772275001, ; 546: Microsoft.EntityFrameworkCore.dll => 0xc425763635a1c339 => 178
	i64 14175662344533632309, ; 547: BarcodeScanning.Native.Maui => 0xc4ba11cbe5cee535 => 173
	i64 14178052285788134900, ; 548: Xamarin.Android.Glide.Annotations.dll => 0xc4c28f6f75511df4 => 225
	i64 14212104595480609394, ; 549: System.Security.Cryptography.Cng.dll => 0xc53b89d4a4518272 => 120
	i64 14220608275227875801, ; 550: System.Diagnostics.FileVersionInfo.dll => 0xc559bfe1def019d9 => 28
	i64 14226382999226559092, ; 551: System.ServiceProcess => 0xc56e43f6938e2a74 => 132
	i64 14232023429000439693, ; 552: System.Resources.Writer.dll => 0xc5824de7789ba78d => 100
	i64 14254574811015963973, ; 553: System.Text.Encoding.Extensions.dll => 0xc5d26c4442d66545 => 134
	i64 14261073672896646636, ; 554: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 282
	i64 14298246716367104064, ; 555: System.Web.dll => 0xc66d93a217f4e840 => 153
	i64 14316535876961222820, ; 556: Xamarin.AndroidX.Camera.Camera2 => 0xc6ae8d872068c0a4 => 238
	i64 14327695147300244862, ; 557: System.Reflection.dll => 0xc6d632d338eb4d7e => 97
	i64 14327709162229390963, ; 558: System.Security.Cryptography.X509Certificates => 0xc6d63f9253cade73 => 125
	i64 14331727281556788554, ; 559: Xamarin.Android.Glide.DiskLruCache.dll => 0xc6e48607a2f7954a => 226
	i64 14346402571976470310, ; 560: System.Net.Ping.dll => 0xc718a920f3686f26 => 69
	i64 14349907877893689639, ; 561: ro\Microsoft.Maui.Controls.resources.dll => 0xc7251d2f956ed127 => 356
	i64 14461014870687870182, ; 562: System.Net.Requests.dll => 0xc8afd8683afdece6 => 72
	i64 14464374589798375073, ; 563: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 357
	i64 14486659737292545672, ; 564: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 267
	i64 14491877563792607819, ; 565: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0xc91d7ddcee4fca4b => 365
	i64 14495724990987328804, ; 566: Xamarin.AndroidX.ResourceInspection.Annotation => 0xc92b2913e18d5d24 => 285
	i64 14524915121004231475, ; 567: Xamarin.JavaX.Inject => 0xc992dd58a4283b33 => 325
	i64 14550104935177758553, ; 568: Xamarin.AndroidX.Camera.Video.dll => 0xc9ec5b5949eda759 => 241
	i64 14551742072151931844, ; 569: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 136
	i64 14556034074661724008, ; 570: CommunityToolkit.Maui.Core => 0xca016bdea6b19f68 => 175
	i64 14561513370130550166, ; 571: System.Security.Cryptography.Primitives.dll => 0xca14e3428abb8d96 => 124
	i64 14574160591280636898, ; 572: System.Net.Quic => 0xca41d1d72ec783e2 => 71
	i64 14610046442689856844, ; 573: cs\Microsoft.Maui.Controls.resources.dll => 0xcac14fd5107d054c => 335
	i64 14622043554576106986, ; 574: System.Runtime.Serialization.Formatters => 0xcaebef2458cc85ea => 111
	i64 14644440854989303794, ; 575: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 277
	i64 14669215534098758659, ; 576: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 192
	i64 14690985099581930927, ; 577: System.Web.HttpUtility => 0xcbe0dd1ca5233daf => 152
	i64 14705122255218365489, ; 578: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 349
	i64 14735017007120366644, ; 579: ja\Microsoft.Maui.Controls.resources.dll => 0xcc7d4be604bfbc34 => 348
	i64 14744092281598614090, ; 580: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 365
	i64 14792063746108907174, ; 581: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 315
	i64 14832630590065248058, ; 582: System.Security.Claims => 0xcdd816ef5d6e873a => 118
	i64 14852515768018889994, ; 583: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 253
	i64 14889905118082851278, ; 584: GoogleGson.dll => 0xcea391d0969961ce => 176
	i64 14904040806490515477, ; 585: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 333
	i64 14905311287502520239, ; 586: Microsoft.Extensions.Hosting.dll => 0xceda4da4ee353faf => 200
	i64 14912225920358050525, ; 587: System.Security.Principal.Windows => 0xcef2de7759506add => 127
	i64 14935719434541007538, ; 588: System.Text.Encoding.CodePages.dll => 0xcf4655b160b702b2 => 133
	i64 14954917835170835695, ; 589: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 193
	i64 14984936317414011727, ; 590: System.Net.WebHeaderCollection => 0xcff5302fe54ff34f => 77
	i64 14987728460634540364, ; 591: System.IO.Compression.dll => 0xcfff1ba06622494c => 46
	i64 14988210264188246988, ; 592: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 256
	i64 15004680457737980385, ; 593: Microsoft.Extensions.Configuration.UserSecrets => 0xd03b5560cbb7c9e1 => 191
	i64 15015154896917945444, ; 594: System.Net.Security.dll => 0xd0608bd33642dc64 => 73
	i64 15024878362326791334, ; 595: System.Net.Http.Json => 0xd0831743ebf0f4a6 => 63
	i64 15051741671811457419, ; 596: Microsoft.Extensions.Diagnostics.Abstractions.dll => 0xd0e2874d8f44218b => 196
	i64 15071021337266399595, ; 597: System.Resources.Reader.dll => 0xd127060e7a18a96b => 98
	i64 15076659072870671916, ; 598: System.ObjectModel.dll => 0xd13b0d8c1620662c => 84
	i64 15111608613780139878, ; 599: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 350
	i64 15115185479366240210, ; 600: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 43
	i64 15133485256822086103, ; 601: System.Linq.dll => 0xd204f0a9127dd9d7 => 61
	i64 15150743910298169673, ; 602: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xd2424150783c3149 => 283
	i64 15203009853192377507, ; 603: pt\Microsoft.Maui.Controls.resources.dll => 0xd2fbf0e9984b94a3 => 355
	i64 15227001540531775957, ; 604: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 185
	i64 15234786388537674379, ; 605: System.Dynamic.Runtime.dll => 0xd36cd580c5be8a8b => 37
	i64 15250465174479574862, ; 606: System.Globalization.Calendars.dll => 0xd3a489469852174e => 40
	i64 15272359115529052076, ; 607: Xamarin.AndroidX.Collection.Ktx => 0xd3f251b2fb4edfac => 246
	i64 15279429628684179188, ; 608: Xamarin.KotlinX.Coroutines.Android.dll => 0xd40b704b1c4c96f4 => 330
	i64 15299439993936780255, ; 609: System.Xml.XPath.dll => 0xd452879d55019bdf => 160
	i64 15338463749992804988, ; 610: System.Resources.Reader => 0xd4dd2b839286f27c => 98
	i64 15370334346939861994, ; 611: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 251
	i64 15391712275433856905, ; 612: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 193
	i64 15475196252089753159, ; 613: System.Diagnostics.EventLog => 0xd6c2f1000b441e47 => 223
	i64 15526743539506359484, ; 614: System.Text.Encoding.dll => 0xd77a12fc26de2cbc => 135
	i64 15527772828719725935, ; 615: System.Console => 0xd77dbb1e38cd3d6f => 20
	i64 15530465045505749832, ; 616: System.Net.HttpListener.dll => 0xd7874bacc9fdb348 => 65
	i64 15536481058354060254, ; 617: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 337
	i64 15541854775306130054, ; 618: System.Security.Cryptography.X509Certificates.dll => 0xd7afc292e8d49286 => 125
	i64 15557562860424774966, ; 619: System.Net.Sockets => 0xd7e790fe7a6dc536 => 75
	i64 15582737692548360875, ; 620: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 275
	i64 15609085926864131306, ; 621: System.dll => 0xd89e9cf3334914ea => 164
	i64 15620595871140898079, ; 622: Microsoft.Extensions.DependencyModel => 0xd8c7812eef49651f => 194
	i64 15661133872274321916, ; 623: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 156
	i64 15710114879900314733, ; 624: Microsoft.Win32.Registry => 0xda058a3f5d096c6d => 5
	i64 15750144475371186037, ; 625: Xamarin.AndroidX.Camera.View.dll => 0xda93c0f3d794a775 => 242
	i64 15755368083429170162, ; 626: System.IO.FileSystem.Primitives => 0xdaa64fcbde529bf2 => 49
	i64 15777549416145007739, ; 627: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 289
	i64 15783653065526199428, ; 628: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 338
	i64 15817206913877585035, ; 629: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 144
	i64 15827202283623377193, ; 630: Microsoft.Extensions.Configuration.Json.dll => 0xdba5849eef9f6929 => 190
	i64 15847085070278954535, ; 631: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 139
	i64 15885744048853936810, ; 632: System.Resources.Writer => 0xdc75800bd0b6eaaa => 100
	i64 15915482068648965105, ; 633: Microsoft.Extensions.Configuration.EnvironmentVariables => 0xdcdf269e1aebb3f1 => 188
	i64 15928521404965645318, ; 634: Microsoft.Maui.Controls.Compatibility => 0xdd0d79d32c2eec06 => 212
	i64 15930129725311349754, ; 635: Xamarin.GooglePlayServices.Tasks.dll => 0xdd1330956f12f3fa => 324
	i64 15934062614519587357, ; 636: System.Security.Cryptography.OpenSsl => 0xdd2129868f45a21d => 123
	i64 15937190497610202713, ; 637: System.Security.Cryptography.Cng => 0xdd2c465197c97e59 => 120
	i64 15959458866502526117, ; 638: Microsoft.Extensions.Configuration.EnvironmentVariables.dll => 0xdd7b6348415764a5 => 188
	i64 15963349826457351533, ; 639: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 142
	i64 15971679995444160383, ; 640: System.Formats.Tar.dll => 0xdda6ce5592a9677f => 39
	i64 16014002616147871184, ; 641: DTO => 0xde3d2a8897ab85d0 => 368
	i64 16018552496348375205, ; 642: System.Net.NetworkInformation.dll => 0xde4d54a020caa8a5 => 68
	i64 16054465462676478687, ; 643: System.Globalization.Extensions => 0xdecceb47319bdadf => 41
	i64 16056281320585338352, ; 644: ru\Microsoft.Maui.Controls.resources.dll => 0xded35eca8f3a9df0 => 357
	i64 16108512836893304087, ; 645: BarcodeScanning.Native.Maui.dll => 0xdf8cef141ed86517 => 173
	i64 16154507427712707110, ; 646: System => 0xe03056ea4e39aa26 => 164
	i64 16219561732052121626, ; 647: System.Net.Security => 0xe1177575db7c781a => 73
	i64 16288847719894691167, ; 648: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 351
	i64 16315482530584035869, ; 649: WindowsBase.dll => 0xe26c3ceb1e8d821d => 165
	i64 16321164108206115771, ; 650: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 203
	i64 16337011941688632206, ; 651: System.Security.Principal.Windows.dll => 0xe2b8b9cdc3aa638e => 127
	i64 16361933716545543812, ; 652: Xamarin.AndroidX.ExifInterface.dll => 0xe3114406a52f1e84 => 261
	i64 16423015068819898779, ; 653: Xamarin.Kotlin.StdLib.Jdk8 => 0xe3ea453135e5c19b => 329
	i64 16454459195343277943, ; 654: System.Net.NetworkInformation => 0xe459fb756d988f77 => 68
	i64 16467346005009053642, ; 655: Xamarin.Google.Android.DataTransport.TransportApi => 0xe487c3f19e0337ca => 306
	i64 16496768397145114574, ; 656: Mono.Android.Export.dll => 0xe4f04b741db987ce => 169
	i64 16589693266713801121, ; 657: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xe63a6e214f2a71a1 => 274
	i64 16621146507174665210, ; 658: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 248
	i64 16649148416072044166, ; 659: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 217
	i64 16677317093839702854, ; 660: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 281
	i64 16702652415771857902, ; 661: System.ValueTuple => 0xe7cbbde0b0e6d3ee => 151
	i64 16709499819875633724, ; 662: System.IO.Compression.ZipFile => 0xe7e4118e32240a3c => 45
	i64 16737807731308835127, ; 663: System.Runtime.Intrinsics => 0xe848a3736f733137 => 108
	i64 16755018182064898362, ; 664: SQLitePCLRaw.core.dll => 0xe885c843c330813a => 220
	i64 16758309481308491337, ; 665: System.IO.FileSystem.DriveInfo => 0xe89179af15740e49 => 48
	i64 16762783179241323229, ; 666: System.Reflection.TypeExtensions => 0xe8a15e7d0d927add => 96
	i64 16765015072123548030, ; 667: System.Diagnostics.TextWriterTraceListener.dll => 0xe8a94c621bfe717e => 31
	i64 16803648858859583026, ; 668: ms\Microsoft.Maui.Controls.resources.dll => 0xe9328d9b8ab93632 => 350
	i64 16822611501064131242, ; 669: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 23
	i64 16833383113903931215, ; 670: mscorlib => 0xe99c30c1484d7f4f => 166
	i64 16856067890322379635, ; 671: System.Data.Common.dll => 0xe9ecc87060889373 => 22
	i64 16890310621557459193, ; 672: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 138
	i64 16933958494752847024, ; 673: System.Net.WebProxy.dll => 0xeb018187f0f3b4b0 => 78
	i64 16942731696432749159, ; 674: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 358
	i64 16977952268158210142, ; 675: System.IO.Pipes.AccessControl => 0xeb9dcda2851b905e => 54
	i64 16989020923549080504, ; 676: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xebc52084add25bb8 => 274
	i64 16998075588627545693, ; 677: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 279
	i64 17008137082415910100, ; 678: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 10
	i64 17024911836938395553, ; 679: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 231
	i64 17031351772568316411, ; 680: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 278
	i64 17037200463775726619, ; 681: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 265
	i64 17047433665992082296, ; 682: Microsoft.Extensions.Configuration.FileExtensions => 0xec94a699197e4378 => 189
	i64 17062143951396181894, ; 683: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 16
	i64 17071469805149661853, ; 684: Microsoft.Extensions.Configuration.UserSecrets.dll => 0xecea0b56d9c0aa9d => 191
	i64 17118171214553292978, ; 685: System.Threading.Channels => 0xed8ff6060fc420b2 => 139
	i64 17187273293601214786, ; 686: System.ComponentModel.Annotations.dll => 0xee8575ff9aa89142 => 13
	i64 17201328579425343169, ; 687: System.ComponentModel.EventBasedAsync => 0xeeb76534d96c16c1 => 15
	i64 17202182880784296190, ; 688: System.Security.Cryptography.Encoding.dll => 0xeeba6e30627428fe => 122
	i64 17203614576212522419, ; 689: pl\Microsoft.Maui.Controls.resources.dll => 0xeebf844ef3e135b3 => 353
	i64 17205988430934219272, ; 690: Microsoft.Extensions.FileSystemGlobbing => 0xeec7f35113509a08 => 199
	i64 17230721278011714856, ; 691: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 87
	i64 17234219099804750107, ; 692: System.Transactions.Local.dll => 0xef2c3ef5e11d511b => 149
	i64 17260702271250283638, ; 693: System.Data.Common => 0xef8a5543bba6bc76 => 22
	i64 17310278548634113468, ; 694: hi\Microsoft.Maui.Controls.resources.dll => 0xf03a76a04e6695bc => 343
	i64 17314848919636016994, ; 695: Core => 0xf04ab35aba75ff62 => 367
	i64 17333249706306540043, ; 696: System.Diagnostics.Tracing.dll => 0xf08c12c5bb8b920b => 34
	i64 17338386382517543202, ; 697: System.Net.WebSockets.Client.dll => 0xf09e528d5c6da122 => 79
	i64 17342750010158924305, ; 698: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 343
	i64 17360349973592121190, ; 699: Xamarin.Google.Crypto.Tink.Android => 0xf0ec5a52686b9f66 => 313
	i64 17417564145681574048, ; 700: Xamarin.Google.Android.ODML.Image => 0xf1b79e4eebee28a0 => 310
	i64 17434242208926550937, ; 701: Xamarin.Google.Android.DataTransport.TransportRuntime => 0xf1f2deeb1f304b99 => 308
	i64 17470386307322966175, ; 702: System.Threading.Timer => 0xf27347c8d0d5709f => 147
	i64 17509662556995089465, ; 703: System.Net.WebSockets.dll => 0xf2fed1534ea67439 => 80
	i64 17514990004910432069, ; 704: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 341
	i64 17522591619082469157, ; 705: GoogleGson => 0xf32cc03d27a5bf25 => 176
	i64 17590473451926037903, ; 706: Xamarin.Android.Glide => 0xf41dea67fcfda58f => 224
	i64 17623389608345532001, ; 707: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 353
	i64 17627500474728259406, ; 708: System.Globalization => 0xf4a176498a351f4e => 42
	i64 17685921127322830888, ; 709: System.Diagnostics.Debug.dll => 0xf571038fafa74828 => 26
	i64 17704177640604968747, ; 710: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 276
	i64 17710060891934109755, ; 711: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 273
	i64 17712670374920797664, ; 712: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 107
	i64 17777860260071588075, ; 713: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 110
	i64 17827813215687577648, ; 714: hr\Microsoft.Maui.Controls.resources.dll => 0xf7691da9f3129030 => 344
	i64 17838668724098252521, ; 715: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 7
	i64 17891337867145587222, ; 716: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 326
	i64 17928294245072900555, ; 717: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 44
	i64 17942426894774770628, ; 718: de\Microsoft.Maui.Controls.resources.dll => 0xf9004e329f771bc4 => 337
	i64 17945795017270165205, ; 719: Xamarin.Google.Android.DataTransport.TransportApi.dll => 0xf90c457cc05cfed5 => 306
	i64 17986907704309214542, ; 720: Xamarin.GooglePlayServices.Basement.dll => 0xf99e554223166d4e => 322
	i64 17989840619545221262, ; 721: Xamarin.Google.MLKit.BarcodeScanning.Common.dll => 0xf9a8c0baade2d88e => 317
	i64 17992315986609351877, ; 722: System.Xml.XmlDocument.dll => 0xf9b18c0ffc6eacc5 => 161
	i64 18017743553296241350, ; 723: Microsoft.Extensions.Caching.Abstractions => 0xfa0be24cb44e92c6 => 182
	i64 18025913125965088385, ; 724: System.Threading => 0xfa28e87b91334681 => 148
	i64 18116111925905154859, ; 725: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 236
	i64 18121036031235206392, ; 726: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 278
	i64 18146411883821974900, ; 727: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 38
	i64 18146811631844267958, ; 728: System.ComponentModel.EventBasedAsync.dll => 0xfbd66d08820117b6 => 15
	i64 18225059387460068507, ; 729: System.Threading.ThreadPool.dll => 0xfcec6af3cff4a49b => 146
	i64 18245806341561545090, ; 730: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 8
	i64 18260797123374478311, ; 731: Xamarin.AndroidX.Emoji2 => 0xfd6b623bde35f3e7 => 259
	i64 18305135509493619199, ; 732: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 280
	i64 18318849532986632368, ; 733: System.Security.dll => 0xfe39a097c37fa8b0 => 130
	i64 18324163916253801303, ; 734: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 347
	i64 18342408478508122430, ; 735: id\Microsoft.Maui.Controls.resources.dll => 0xfe8d53543697013e => 346
	i64 18358161419737137786, ; 736: he\Microsoft.Maui.Controls.resources.dll => 0xfec54a8ba8b6827a => 342
	i64 18370042311372477656, ; 737: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0xfeef80274e4094d8 => 221
	i64 18380184030268848184, ; 738: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 296
	i64 18439108438687598470 ; 739: System.Reflection.Metadata.dll => 0xffe4df6e2ee1c786 => 94
], align 8

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [740 x i32] [
	i32 258, ; 0
	i32 211, ; 1
	i32 171, ; 2
	i32 216, ; 3
	i32 201, ; 4
	i32 58, ; 5
	i32 244, ; 6
	i32 151, ; 7
	i32 286, ; 8
	i32 245, ; 9
	i32 289, ; 10
	i32 252, ; 11
	i32 132, ; 12
	i32 210, ; 13
	i32 56, ; 14
	i32 288, ; 15
	i32 95, ; 16
	i32 271, ; 17
	i32 189, ; 18
	i32 129, ; 19
	i32 186, ; 20
	i32 321, ; 21
	i32 145, ; 22
	i32 246, ; 23
	i32 18, ; 24
	i32 345, ; 25
	i32 221, ; 26
	i32 257, ; 27
	i32 272, ; 28
	i32 241, ; 29
	i32 150, ; 30
	i32 104, ; 31
	i32 95, ; 32
	i32 309, ; 33
	i32 36, ; 34
	i32 220, ; 35
	i32 28, ; 36
	i32 235, ; 37
	i32 279, ; 38
	i32 50, ; 39
	i32 115, ; 40
	i32 302, ; 41
	i32 70, ; 42
	i32 213, ; 43
	i32 311, ; 44
	i32 65, ; 45
	i32 170, ; 46
	i32 222, ; 47
	i32 145, ; 48
	i32 300, ; 49
	i32 234, ; 50
	i32 275, ; 51
	i32 265, ; 52
	i32 320, ; 53
	i32 40, ; 54
	i32 89, ; 55
	i32 177, ; 56
	i32 81, ; 57
	i32 66, ; 58
	i32 62, ; 59
	i32 86, ; 60
	i32 233, ; 61
	i32 106, ; 62
	i32 339, ; 63
	i32 286, ; 64
	i32 307, ; 65
	i32 102, ; 66
	i32 35, ; 67
	i32 230, ; 68
	i32 361, ; 69
	i32 288, ; 70
	i32 214, ; 71
	i32 119, ; 72
	i32 273, ; 73
	i32 142, ; 74
	i32 141, ; 75
	i32 328, ; 76
	i32 53, ; 77
	i32 35, ; 78
	i32 141, ; 79
	i32 238, ; 80
	i32 227, ; 81
	i32 237, ; 82
	i32 179, ; 83
	i32 206, ; 84
	i32 331, ; 85
	i32 257, ; 86
	i32 8, ; 87
	i32 14, ; 88
	i32 285, ; 89
	i32 51, ; 90
	i32 268, ; 91
	i32 136, ; 92
	i32 101, ; 93
	i32 250, ; 94
	i32 295, ; 95
	i32 116, ; 96
	i32 228, ; 97
	i32 163, ; 98
	i32 360, ; 99
	i32 166, ; 100
	i32 67, ; 101
	i32 192, ; 102
	i32 335, ; 103
	i32 80, ; 104
	i32 101, ; 105
	i32 290, ; 106
	i32 117, ; 107
	i32 340, ; 108
	i32 200, ; 109
	i32 312, ; 110
	i32 78, ; 111
	i32 309, ; 112
	i32 114, ; 113
	i32 121, ; 114
	i32 48, ; 115
	i32 303, ; 116
	i32 201, ; 117
	i32 128, ; 118
	i32 266, ; 119
	i32 207, ; 120
	i32 231, ; 121
	i32 82, ; 122
	i32 110, ; 123
	i32 75, ; 124
	i32 332, ; 125
	i32 197, ; 126
	i32 322, ; 127
	i32 216, ; 128
	i32 53, ; 129
	i32 292, ; 130
	i32 184, ; 131
	i32 69, ; 132
	i32 291, ; 133
	i32 183, ; 134
	i32 83, ; 135
	i32 172, ; 136
	i32 355, ; 137
	i32 116, ; 138
	i32 185, ; 139
	i32 156, ; 140
	i32 184, ; 141
	i32 225, ; 142
	i32 167, ; 143
	i32 284, ; 144
	i32 258, ; 145
	i32 202, ; 146
	i32 32, ; 147
	i32 198, ; 148
	i32 214, ; 149
	i32 122, ; 150
	i32 323, ; 151
	i32 72, ; 152
	i32 62, ; 153
	i32 0, ; 154
	i32 161, ; 155
	i32 113, ; 156
	i32 336, ; 157
	i32 88, ; 158
	i32 212, ; 159
	i32 366, ; 160
	i32 105, ; 161
	i32 18, ; 162
	i32 146, ; 163
	i32 118, ; 164
	i32 58, ; 165
	i32 252, ; 166
	i32 17, ; 167
	i32 52, ; 168
	i32 304, ; 169
	i32 324, ; 170
	i32 320, ; 171
	i32 92, ; 172
	i32 223, ; 173
	i32 307, ; 174
	i32 219, ; 175
	i32 361, ; 176
	i32 55, ; 177
	i32 129, ; 178
	i32 205, ; 179
	i32 152, ; 180
	i32 41, ; 181
	i32 180, ; 182
	i32 92, ; 183
	i32 367, ; 184
	i32 179, ; 185
	i32 318, ; 186
	i32 296, ; 187
	i32 50, ; 188
	i32 302, ; 189
	i32 162, ; 190
	i32 240, ; 191
	i32 13, ; 192
	i32 205, ; 193
	i32 270, ; 194
	i32 228, ; 195
	i32 291, ; 196
	i32 36, ; 197
	i32 67, ; 198
	i32 109, ; 199
	i32 351, ; 200
	i32 359, ; 201
	i32 319, ; 202
	i32 318, ; 203
	i32 229, ; 204
	i32 99, ; 205
	i32 99, ; 206
	i32 11, ; 207
	i32 177, ; 208
	i32 11, ; 209
	i32 277, ; 210
	i32 25, ; 211
	i32 128, ; 212
	i32 76, ; 213
	i32 269, ; 214
	i32 109, ; 215
	i32 295, ; 216
	i32 293, ; 217
	i32 106, ; 218
	i32 2, ; 219
	i32 26, ; 220
	i32 248, ; 221
	i32 319, ; 222
	i32 157, ; 223
	i32 359, ; 224
	i32 21, ; 225
	i32 362, ; 226
	i32 49, ; 227
	i32 207, ; 228
	i32 43, ; 229
	i32 126, ; 230
	i32 232, ; 231
	i32 59, ; 232
	i32 119, ; 233
	i32 298, ; 234
	i32 261, ; 235
	i32 247, ; 236
	i32 3, ; 237
	i32 267, ; 238
	i32 287, ; 239
	i32 38, ; 240
	i32 124, ; 241
	i32 195, ; 242
	i32 287, ; 243
	i32 187, ; 244
	i32 219, ; 245
	i32 356, ; 246
	i32 137, ; 247
	i32 149, ; 248
	i32 85, ; 249
	i32 90, ; 250
	i32 339, ; 251
	i32 271, ; 252
	i32 369, ; 253
	i32 268, ; 254
	i32 340, ; 255
	i32 344, ; 256
	i32 237, ; 257
	i32 254, ; 258
	i32 299, ; 259
	i32 209, ; 260
	i32 314, ; 261
	i32 269, ; 262
	i32 133, ; 263
	i32 96, ; 264
	i32 3, ; 265
	i32 352, ; 266
	i32 105, ; 267
	i32 33, ; 268
	i32 154, ; 269
	i32 158, ; 270
	i32 155, ; 271
	i32 308, ; 272
	i32 82, ; 273
	i32 301, ; 274
	i32 263, ; 275
	i32 305, ; 276
	i32 143, ; 277
	i32 87, ; 278
	i32 19, ; 279
	i32 264, ; 280
	i32 51, ; 281
	i32 227, ; 282
	i32 61, ; 283
	i32 54, ; 284
	i32 4, ; 285
	i32 97, ; 286
	i32 226, ; 287
	i32 17, ; 288
	i32 304, ; 289
	i32 155, ; 290
	i32 84, ; 291
	i32 29, ; 292
	i32 45, ; 293
	i32 64, ; 294
	i32 66, ; 295
	i32 172, ; 296
	i32 272, ; 297
	i32 1, ; 298
	i32 327, ; 299
	i32 347, ; 300
	i32 311, ; 301
	i32 47, ; 302
	i32 24, ; 303
	i32 234, ; 304
	i32 196, ; 305
	i32 204, ; 306
	i32 182, ; 307
	i32 358, ; 308
	i32 165, ; 309
	i32 108, ; 310
	i32 204, ; 311
	i32 12, ; 312
	i32 266, ; 313
	i32 63, ; 314
	i32 27, ; 315
	i32 23, ; 316
	i32 349, ; 317
	i32 93, ; 318
	i32 168, ; 319
	i32 12, ; 320
	i32 330, ; 321
	i32 217, ; 322
	i32 29, ; 323
	i32 103, ; 324
	i32 14, ; 325
	i32 242, ; 326
	i32 126, ; 327
	i32 364, ; 328
	i32 249, ; 329
	i32 281, ; 330
	i32 91, ; 331
	i32 270, ; 332
	i32 187, ; 333
	i32 9, ; 334
	i32 86, ; 335
	i32 260, ; 336
	i32 174, ; 337
	i32 293, ; 338
	i32 71, ; 339
	i32 168, ; 340
	i32 239, ; 341
	i32 1, ; 342
	i32 280, ; 343
	i32 5, ; 344
	i32 354, ; 345
	i32 44, ; 346
	i32 208, ; 347
	i32 27, ; 348
	i32 195, ; 349
	i32 158, ; 350
	i32 283, ; 351
	i32 112, ; 352
	i32 331, ; 353
	i32 364, ; 354
	i32 183, ; 355
	i32 239, ; 356
	i32 121, ; 357
	i32 178, ; 358
	i32 298, ; 359
	i32 233, ; 360
	i32 338, ; 361
	i32 159, ; 362
	i32 362, ; 363
	i32 131, ; 364
	i32 313, ; 365
	i32 57, ; 366
	i32 317, ; 367
	i32 190, ; 368
	i32 138, ; 369
	i32 83, ; 370
	i32 30, ; 371
	i32 250, ; 372
	i32 10, ; 373
	i32 305, ; 374
	i32 334, ; 375
	i32 300, ; 376
	i32 171, ; 377
	i32 247, ; 378
	i32 150, ; 379
	i32 94, ; 380
	i32 181, ; 381
	i32 321, ; 382
	i32 316, ; 383
	i32 260, ; 384
	i32 60, ; 385
	i32 215, ; 386
	i32 157, ; 387
	i32 206, ; 388
	i32 64, ; 389
	i32 88, ; 390
	i32 79, ; 391
	i32 47, ; 392
	i32 213, ; 393
	i32 143, ; 394
	i32 336, ; 395
	i32 0, ; 396
	i32 186, ; 397
	i32 352, ; 398
	i32 328, ; 399
	i32 254, ; 400
	i32 74, ; 401
	i32 91, ; 402
	i32 326, ; 403
	i32 135, ; 404
	i32 90, ; 405
	i32 292, ; 406
	i32 332, ; 407
	i32 251, ; 408
	i32 334, ; 409
	i32 112, ; 410
	i32 42, ; 411
	i32 159, ; 412
	i32 4, ; 413
	i32 103, ; 414
	i32 366, ; 415
	i32 70, ; 416
	i32 210, ; 417
	i32 180, ; 418
	i32 60, ; 419
	i32 39, ; 420
	i32 235, ; 421
	i32 174, ; 422
	i32 153, ; 423
	i32 56, ; 424
	i32 34, ; 425
	i32 203, ; 426
	i32 208, ; 427
	i32 215, ; 428
	i32 232, ; 429
	i32 21, ; 430
	i32 163, ; 431
	i32 314, ; 432
	i32 345, ; 433
	i32 312, ; 434
	i32 360, ; 435
	i32 341, ; 436
	i32 297, ; 437
	i32 140, ; 438
	i32 348, ; 439
	i32 209, ; 440
	i32 89, ; 441
	i32 245, ; 442
	i32 147, ; 443
	i32 253, ; 444
	i32 162, ; 445
	i32 301, ; 446
	i32 282, ; 447
	i32 181, ; 448
	i32 6, ; 449
	i32 169, ; 450
	i32 31, ; 451
	i32 107, ; 452
	i32 263, ; 453
	i32 346, ; 454
	i32 297, ; 455
	i32 202, ; 456
	i32 230, ; 457
	i32 290, ; 458
	i32 167, ; 459
	i32 264, ; 460
	i32 140, ; 461
	i32 59, ; 462
	i32 218, ; 463
	i32 144, ; 464
	i32 218, ; 465
	i32 363, ; 466
	i32 310, ; 467
	i32 81, ; 468
	i32 74, ; 469
	i32 198, ; 470
	i32 199, ; 471
	i32 130, ; 472
	i32 25, ; 473
	i32 7, ; 474
	i32 93, ; 475
	i32 294, ; 476
	i32 137, ; 477
	i32 224, ; 478
	i32 113, ; 479
	i32 9, ; 480
	i32 222, ; 481
	i32 104, ; 482
	i32 175, ; 483
	i32 325, ; 484
	i32 19, ; 485
	i32 262, ; 486
	i32 276, ; 487
	i32 369, ; 488
	i32 256, ; 489
	i32 33, ; 490
	i32 243, ; 491
	i32 46, ; 492
	i32 30, ; 493
	i32 244, ; 494
	i32 57, ; 495
	i32 134, ; 496
	i32 114, ; 497
	i32 299, ; 498
	i32 240, ; 499
	i32 368, ; 500
	i32 323, ; 501
	i32 329, ; 502
	i32 55, ; 503
	i32 211, ; 504
	i32 6, ; 505
	i32 303, ; 506
	i32 77, ; 507
	i32 316, ; 508
	i32 255, ; 509
	i32 333, ; 510
	i32 354, ; 511
	i32 111, ; 512
	i32 259, ; 513
	i32 102, ; 514
	i32 170, ; 515
	i32 115, ; 516
	i32 342, ; 517
	i32 294, ; 518
	i32 249, ; 519
	i32 76, ; 520
	i32 315, ; 521
	i32 85, ; 522
	i32 327, ; 523
	i32 236, ; 524
	i32 363, ; 525
	i32 197, ; 526
	i32 284, ; 527
	i32 160, ; 528
	i32 2, ; 529
	i32 255, ; 530
	i32 24, ; 531
	i32 229, ; 532
	i32 32, ; 533
	i32 117, ; 534
	i32 37, ; 535
	i32 16, ; 536
	i32 52, ; 537
	i32 20, ; 538
	i32 123, ; 539
	i32 154, ; 540
	i32 194, ; 541
	i32 262, ; 542
	i32 131, ; 543
	i32 243, ; 544
	i32 148, ; 545
	i32 178, ; 546
	i32 173, ; 547
	i32 225, ; 548
	i32 120, ; 549
	i32 28, ; 550
	i32 132, ; 551
	i32 100, ; 552
	i32 134, ; 553
	i32 282, ; 554
	i32 153, ; 555
	i32 238, ; 556
	i32 97, ; 557
	i32 125, ; 558
	i32 226, ; 559
	i32 69, ; 560
	i32 356, ; 561
	i32 72, ; 562
	i32 357, ; 563
	i32 267, ; 564
	i32 365, ; 565
	i32 285, ; 566
	i32 325, ; 567
	i32 241, ; 568
	i32 136, ; 569
	i32 175, ; 570
	i32 124, ; 571
	i32 71, ; 572
	i32 335, ; 573
	i32 111, ; 574
	i32 277, ; 575
	i32 192, ; 576
	i32 152, ; 577
	i32 349, ; 578
	i32 348, ; 579
	i32 365, ; 580
	i32 315, ; 581
	i32 118, ; 582
	i32 253, ; 583
	i32 176, ; 584
	i32 333, ; 585
	i32 200, ; 586
	i32 127, ; 587
	i32 133, ; 588
	i32 193, ; 589
	i32 77, ; 590
	i32 46, ; 591
	i32 256, ; 592
	i32 191, ; 593
	i32 73, ; 594
	i32 63, ; 595
	i32 196, ; 596
	i32 98, ; 597
	i32 84, ; 598
	i32 350, ; 599
	i32 43, ; 600
	i32 61, ; 601
	i32 283, ; 602
	i32 355, ; 603
	i32 185, ; 604
	i32 37, ; 605
	i32 40, ; 606
	i32 246, ; 607
	i32 330, ; 608
	i32 160, ; 609
	i32 98, ; 610
	i32 251, ; 611
	i32 193, ; 612
	i32 223, ; 613
	i32 135, ; 614
	i32 20, ; 615
	i32 65, ; 616
	i32 337, ; 617
	i32 125, ; 618
	i32 75, ; 619
	i32 275, ; 620
	i32 164, ; 621
	i32 194, ; 622
	i32 156, ; 623
	i32 5, ; 624
	i32 242, ; 625
	i32 49, ; 626
	i32 289, ; 627
	i32 338, ; 628
	i32 144, ; 629
	i32 190, ; 630
	i32 139, ; 631
	i32 100, ; 632
	i32 188, ; 633
	i32 212, ; 634
	i32 324, ; 635
	i32 123, ; 636
	i32 120, ; 637
	i32 188, ; 638
	i32 142, ; 639
	i32 39, ; 640
	i32 368, ; 641
	i32 68, ; 642
	i32 41, ; 643
	i32 357, ; 644
	i32 173, ; 645
	i32 164, ; 646
	i32 73, ; 647
	i32 351, ; 648
	i32 165, ; 649
	i32 203, ; 650
	i32 127, ; 651
	i32 261, ; 652
	i32 329, ; 653
	i32 68, ; 654
	i32 306, ; 655
	i32 169, ; 656
	i32 274, ; 657
	i32 248, ; 658
	i32 217, ; 659
	i32 281, ; 660
	i32 151, ; 661
	i32 45, ; 662
	i32 108, ; 663
	i32 220, ; 664
	i32 48, ; 665
	i32 96, ; 666
	i32 31, ; 667
	i32 350, ; 668
	i32 23, ; 669
	i32 166, ; 670
	i32 22, ; 671
	i32 138, ; 672
	i32 78, ; 673
	i32 358, ; 674
	i32 54, ; 675
	i32 274, ; 676
	i32 279, ; 677
	i32 10, ; 678
	i32 231, ; 679
	i32 278, ; 680
	i32 265, ; 681
	i32 189, ; 682
	i32 16, ; 683
	i32 191, ; 684
	i32 139, ; 685
	i32 13, ; 686
	i32 15, ; 687
	i32 122, ; 688
	i32 353, ; 689
	i32 199, ; 690
	i32 87, ; 691
	i32 149, ; 692
	i32 22, ; 693
	i32 343, ; 694
	i32 367, ; 695
	i32 34, ; 696
	i32 79, ; 697
	i32 343, ; 698
	i32 313, ; 699
	i32 310, ; 700
	i32 308, ; 701
	i32 147, ; 702
	i32 80, ; 703
	i32 341, ; 704
	i32 176, ; 705
	i32 224, ; 706
	i32 353, ; 707
	i32 42, ; 708
	i32 26, ; 709
	i32 276, ; 710
	i32 273, ; 711
	i32 107, ; 712
	i32 110, ; 713
	i32 344, ; 714
	i32 7, ; 715
	i32 326, ; 716
	i32 44, ; 717
	i32 337, ; 718
	i32 306, ; 719
	i32 322, ; 720
	i32 317, ; 721
	i32 161, ; 722
	i32 182, ; 723
	i32 148, ; 724
	i32 236, ; 725
	i32 278, ; 726
	i32 38, ; 727
	i32 15, ; 728
	i32 146, ; 729
	i32 8, ; 730
	i32 259, ; 731
	i32 280, ; 732
	i32 130, ; 733
	i32 347, ; 734
	i32 346, ; 735
	i32 342, ; 736
	i32 221, ; 737
	i32 296, ; 738
	i32 94 ; 739
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" }

; Metadata
!llvm.module.flags = !{!0, !1, !7, !8, !9, !10}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ 87e4a6d890397c13b2572ce01d4b57874ecef9b0"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"branch-target-enforcement", i32 0}
!8 = !{i32 1, !"sign-return-address", i32 0}
!9 = !{i32 1, !"sign-return-address-all", i32 0}
!10 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
