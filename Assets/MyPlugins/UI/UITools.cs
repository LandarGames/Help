using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public static class UITools
    {
        #region Cell
        private static int _currentStep = 1;
        private static int _stepLeft;

        public static void AddCell(this RectTransform content)
        {
            _stepLeft++;

            if(_stepLeft < _currentStep)
                return;

            GridLayoutGroup grid = content.GetComponent<GridLayoutGroup>();
            content.sizeDelta = new UnityEngine.Vector2(content.sizeDelta.x, content.sizeDelta.y + grid.cellSize.y + grid.spacing.y);
            _stepLeft = 0;
        }
        public static void ClearCell(this RectTransform content)
        {
            content.sizeDelta = new UnityEngine.Vector2(content.sizeDelta.x, 0);
        }

        public static void SetStep(int step)
        {
            _currentStep = step;
        }

        public static void ResetPosition(this RectTransform content)
        {
            content.anchoredPosition = new UnityEngine.Vector2(content.anchoredPosition.x, 0);
        }
        #endregion

        public static string ReducingNumber(BigInteger number)
        {
            string[] suffixes = { "k", "m", "b", "t", "qa", "qi" };
            BigInteger[] thresholds = 
            {
                BigInteger.Parse("1000"),
                BigInteger.Parse("1000000"),
                BigInteger.Parse("1000000000"),
                BigInteger.Parse("1000000000000"),
                BigInteger.Parse("1000000000000000"),
                BigInteger.Parse("1000000000000000000")
            };

            if (number < thresholds[0])
                return number.ToString();

            for (int i = 0; i < thresholds.Length; i++)
            {
                if (number < thresholds[i] * 1000)
                {
                    decimal divisionResult = (decimal)number / (decimal)thresholds[i];
                    return divisionResult.ToString("F2") + suffixes[i];
                }
            }

            return number.ToString();
        }

        public static void SetActive(this CanvasGroup canvasGroup, bool isActive, float alpha = -1)
        {
            if (alpha == -1)
                alpha = isActive ? 1 : 0;

            canvasGroup.alpha = alpha;
            canvasGroup.blocksRaycasts = isActive;
            canvasGroup.interactable = isActive;
        }
    }
}