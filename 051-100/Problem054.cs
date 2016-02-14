using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace EulerProject
{
    [EulerProblem]
    public class Problem054
    {
        // The results I got are of the following order of magnitude:
        //
        // Solution 1: Result = 376 in 45131 ticks

        enum Suit
        {
            Spades,
            Clubs,
            Diamonds,
            Hearts
        }

        class Card : IComparable<Card>
        {
            public Suit suit;
            public int value;

            public static Card Parse(string input)
            {
                if (input.Length != 2)
                    throw new ArgumentException();

                Card ret = new Card();
                switch (input[0])
                {
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        ret.value = int.Parse(input[0].ToString());
                        break;
                    case 'T':
                        ret.value = 10;
                        break;
                    case 'J':
                        ret.value = 11;
                        break;
                    case 'Q':
                        ret.value = 12;
                        break;
                    case 'K':
                        ret.value = 13;
                        break;
                    case 'A':
                        ret.value = 14;
                        break;
                    default:
                        throw new ArgumentException();
                }

                switch (input[1])
                {
                    case 'S':
                        ret.suit = Suit.Spades;
                        break;
                    case 'C':
                        ret.suit = Suit.Clubs;
                        break;
                    case 'D':
                        ret.suit = Suit.Diamonds;
                        break;
                    case 'H':
                        ret.suit = Suit.Hearts;
                        break;
                    default:
                        throw new ArgumentException();
                }

                return ret;
            }

            public int CompareTo(Card other)
            {
                if (value != other.value)
                    return value.CompareTo(other.value);
                return suit != other.suit ? suit.CompareTo(other.suit) : 0;
            }
        }

        class Hand : IComparable<Hand>
        {
            enum HandType
            {
                HighCard,
                OnePair,
                TwoPairs,
                ThreeOfAKind,
                Straight,
                Flush,
                FullHouse,
                FourOfAKind,
                StraightFlush,
                RoyalFlush,
            }

            private readonly Card[] cards;
            private HandType handType;
            private IGrouping<int, Card>[] groups;

            public Hand(IEnumerable<Card> cards)
            {
                if (cards.Count() != 5)
                    throw new ArgumentException();
                this.cards = cards.OrderByDescending(c => c).ToArray();
                Analyze();
            }

            public int CompareTo(Hand other)
            {
                if (handType != other.handType)
                    return handType.CompareTo(other.handType);

                for (int i = 0; i < groups.Length; i++)
                {
                    if (groups[i].Key != other.groups[i].Key)
                        return groups[i].Key.CompareTo(other.groups[i].Key);
                }
                return 0;
            }

            private bool IsStraight()
            {
                return Enumerable.Range(0, 4).All(i => cards[i].value == cards[i + 1].value + 1);
            }

            private void Analyze()
            {
                if (cards.All(c => c.suit == cards[0].suit))
                {
                    if (IsStraight())
                        handType = cards[0].value == 14 ? HandType.RoyalFlush : HandType.StraightFlush;
                    else
                        handType = HandType.Flush;
                }
                else
                {
                    groups = cards.GroupBy(c => c.value)
                                  .OrderByDescending(g => g.Count())
                                  .ThenByDescending(g => g.Key)
                                  .ToArray();
                    switch (groups.Length)
                    {
                        case 2:
                            handType = groups.Any(g => g.Count() == 4) ? HandType.FourOfAKind : HandType.FullHouse;
                            break;
                        case 3:
                            handType = groups.Any(g => g.Count() == 3) ? HandType.ThreeOfAKind : HandType.TwoPairs;
                            break;
                        case 4:
                            handType = HandType.OnePair;
                            break;
                        default:
                            handType = IsStraight() ? HandType.Straight : HandType.HighCard;
                            break;
                    }
                }
            }
        }

        [EulerSolution]
        public static int Solution1(Stopwatch timer)
        {
            timer.Restart();
            int res = 0;
            foreach (var cards in File.ReadAllLines("Problem054.data").Select(s => s.Split().Select(Card.Parse)))
            {
                Hand hand1 = new Hand(cards.Take(5));
                Hand hand2 = new Hand(cards.Skip(5));

                if (hand1.CompareTo(hand2) > 0)
                    res++;
            }
            timer.Stop();
            return res;
        }
    }
}
