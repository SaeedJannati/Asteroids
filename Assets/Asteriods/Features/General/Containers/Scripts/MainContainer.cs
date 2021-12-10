using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContainer
{
    #region Fields

    private static SpaceShipMovementLogic spaceShipMovement;
    private static IMovementInput movementInput;
    private static PlayerInputLogic playerInput;
    private static MovementConfinementLogic movementConfinmentLogic;
    private static AstroidGenerator astroidGenerator;
    private static ScoreLogic scoreLogic;
    private static PlayerHealthLogic playerHealthLogic;
    private static CameraShakeLogic cameraShakeLogic;
    private static PopUpManager popUpManager;
    private static PrefabContainer prefabContainer;
    private static SceneLoader sceneLoader;
    private static GameManger gameManager;
    private static MetaMainMenuLogic metaMainMenuLogic;
    #endregion

    #region properties

    public static SpaceShipMovementLogic SpaceShipMovement
    {
        get => spaceShipMovement;
    }

    public static IMovementInput MovementInput
    {
        get => movementInput;
    }

    public static PlayerInputLogic PlayerInput
    {
        get => playerInput;
    }

    public static MovementConfinementLogic MovementConfinment
    {
        get => movementConfinmentLogic;
    }

    public static AstroidGenerator AstroidGenerator
    {
        get => astroidGenerator;
    }

    public static ScoreLogic ScoreLogic
    {
        get => scoreLogic;
    }

    public static PlayerHealthLogic PlayerHealthLogic
    {
        get => playerHealthLogic;
    }

    public static CameraShakeLogic CameraShakeLogic
    {
        get => cameraShakeLogic;
    }

    public static PopUpManager PopUpManager
    {
        get => popUpManager;
    }

    public static PrefabContainer PrefabContainer
    {
        get => prefabContainer;
    }

    public static SceneLoader SceneLoader
    {
        get => sceneLoader;
    }

    public static GameManger GameManger
    {
        get => gameManager;
    }

    public static MetaMainMenuLogic MetaMainMenuLogic
    {
        get => metaMainMenuLogic;
    }

    #endregion

    #region Mehtodes

    public static void InjectSpaceShipMovementLogic(SpaceShipMovementLogic logic)
    {
        spaceShipMovement = logic;
    }

    public static void InjectMovementInput(IMovementInput input)
    {
        movementInput = input;
    }

    public static void InjectPlayerInputLogic(PlayerInputLogic inputLogic)
    {
        playerInput = inputLogic;
    }

    public static void InjectMoveConfinment(MovementConfinementLogic logic)
    {
        movementConfinmentLogic = logic;
    }

    public static void InjectAstroidGenerator(AstroidGenerator generator)
    {
        astroidGenerator = generator;
    }

    public static void InjectScoreLogic(ScoreLogic logic)
    {
        scoreLogic = logic;
    }

    public static void InjectPlayerHealthLogic(PlayerHealthLogic logic)
    {
        playerHealthLogic = logic;
    }

    public static void InjectCameraShakeLogic(CameraShakeLogic Logic)
    {
        cameraShakeLogic = Logic;
    }

    public static void InjectPopUpManager(PopUpManager manager)
    {
        popUpManager = manager;
    }

    public static void InjectPrefabContainer(PrefabContainer container)
    {
        prefabContainer = container;
    }
    public static void InjectSceneLoader(SceneLoader loader)
    {
        sceneLoader = loader;
    }
    public static void InjectGameManager(GameManger manager)
    {
        gameManager = manager;
    }
    public static void InjectMetaMainMenu(MetaMainMenuLogic logic)
    {
        metaMainMenuLogic = logic;
    }
    #endregion


  
}