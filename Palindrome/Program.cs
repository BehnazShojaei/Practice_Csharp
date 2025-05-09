using System;

// remove spaces, remove special characters, everychar to lower then compare each letter from the beginning and last return true or otherwise

theStr = Regex.Replace(theStr, "[^a-zA-Z0-9]", "").ToLower();