using HarmonyLib;
using ResoniteModLoader;
using FrooxEngine;

namespace NonPersistentInspectors {
	public class NonPersistentInspectors : ResoniteMod {
		internal const string VERSION_CONSTANT = "2.0.0";
		public override string Name => "NeosNonPersistentInspectors";
		public override string Author => "Delta";
		public override string Version => VERSION_CONSTANT;
		public override string Link => "https://github.com/XDelta/NonPersistentInspectors/";

		public override void OnEngineInit() {
			Harmony harmony = new("net.deltawolf.NonPersistentInspectors");
			harmony.PatchAll();
		}

		[HarmonyPatch(typeof(SceneInspector), "OnAttach")]
		static class SceneInspector_OnAttach_Patch {
			static void Postfix(SceneInspector __instance) {
				__instance.Slot.PersistentSelf = false;
			}
		}
	}
}
