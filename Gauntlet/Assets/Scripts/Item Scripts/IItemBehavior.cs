/*
 * Author: [Dorey, Dylan]
 * Last Updated: [4/22/2024]
 * [Item behavior interface]
 */

/// <summary>
/// Interface for an items use behavior
/// </summary>
public interface IItemBehavior
{
    //must implement a behavior method with a player data parameter
    public void Behavior(PlayerData playerData);
}
