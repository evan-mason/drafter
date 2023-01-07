
package com.kevy.drafter.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@NoArgsConstructor
@AllArgsConstructor
@Data
@Entity
@Builder
@Table(name = "players")
public class Player {
	
	@Id
	@GeneratedValue
	private Long id;
	
	private String name;
	
	private Long image;
	
	@ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
	private Team team;
	
	public Player(String name) {
		
		this.name = name;
	}

}