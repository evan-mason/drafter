package com.kevy.drafter.model;

import java.util.Set;

import jakarta.persistence.*;
import lombok.Data;
import lombok.NoArgsConstructor;


@Data
@Entity
@NoArgsConstructor
@Table(name = "teams")
public class Team {
	
	@Id
	@GeneratedValue
	private Long id;
	
	private String name;
	
	private Long image;
	
	@OneToMany(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
	private Set<Player> players;
	
	public Team(String name) {
		
		this.name = name;
	}

}
