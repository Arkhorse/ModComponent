using Newtonsoft.Json.Linq;
using System.Globalization;

namespace ModComponent.Utils
{
	internal class JsonDict : Dictionary<string, JsonDictEntry>
	{

		internal JsonDictEntry? GetEntry(string key)
		{
			if(this.ContainsKey(key))
			{
				return this[key];
			}
			return new JsonDictEntry();
		}

	}

	internal class JsonDictEntry : Dictionary<string, object>
	{

		internal string? GetString(string key, string _default = null)
		{
			if (this.ContainsKey(key))
			{
				return this[key].ToString();
			}
			return _default;
		}
		internal float GetFloat(string key, float _default = 0f)
		{
			if (this.ContainsKey(key) && float.TryParse(this.GetString(key), out float result))
			{
				return result;
			}
			return _default;
		}
		internal int GetInt(string key, int _default = 0)
		{
			if (this.ContainsKey(key))
			{
				return int.Parse(this.GetString(key), CultureInfo.InvariantCulture);
			}
			return _default;
		}
		internal T GetEnum<T>(string key) where T : Enum
		{
			return EnumUtils.ParseEnum<T>(this.GetString(key));
		}
		internal bool GetBool(string key, bool _default = false)
		{
			if (this.ContainsKey(key))
			{
				return bool.Parse(this[key].ToString());
			}
			return _default;
		}
		internal Vector3 GetVector3(string key, Vector3 _default = new Vector3())
		{
			if (this.ContainsKey(key))
			{
				float[] array = (this[key] as JArray).Select(t => t.ToObject<float>()).ToArray();
				if (array.Length == 3)
				{
					return new Vector3(array[0], array[1], array[2]);
				}
			}
			return _default;
		}

		internal T[] GetArray<T>(string key)
		{
			if (this.ContainsKey(key))
			{
				T[] array = (this[key] as JArray).Select(t => t.ToObject<T>()).ToArray();
				return array;

			}
			return [];
		}

	}
}
