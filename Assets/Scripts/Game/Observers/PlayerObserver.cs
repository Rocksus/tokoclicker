using System.Collections;
using System.Collections.Generic;

public interface PlayerStatsObserver {
	void OnUpdateBalance(int balance);

	void OnUpdateOrderRate(int orderRate);
}
